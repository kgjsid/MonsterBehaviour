using UnityEngine;

/// <summary>
/// BaseMonster 클래스. 
/// 모든 몬스터가 상속받아 사용할 부모 클래스.
/// </summary>
public class BaseMonster : StateEntity
{
    protected MonsterStatData monsterStatData;
    protected Transform monsterTransform;
    protected Transform targetTransform;

    protected float detectionCosValue;

    public MonsterStatData MonsterStatData
    {
        get
        {
            return monsterStatData;
        }
        set
        {
            monsterStatData = value;
        }
    }

    public virtual void InitMonsterSetting(MonsterStatData monsterStatData)
    {
        InitStateMachine();
        this.monsterStatData = monsterStatData;
        monsterTransform = transform;
        detectionCosValue = Mathf.Cos(Mathf.Deg2Rad * MonsterStatData.detectionAngle);
    }

    public void CacheTarget(Transform targetTransform)
    {
        this.targetTransform = targetTransform;
    }

    protected virtual bool DetechTarget()
    {
        return CheckDistance() && CheckDirection();
    }

    /// <summary>
    /// 거리 측정용 메소드
    /// </summary>
    /// <returns>가깝다면 true, 멀다면 false</returns>
    protected bool CheckDistance()
    {
        if (targetTransform == null) return false;

        float dist = Vector2.SqrMagnitude(targetTransform.position - monsterTransform.position);
        return dist < MonsterStatData.detectionRange * MonsterStatData.detectionRange;
    }
    
    /// <summary>
    /// target을 바라보고 있는 방향을 체크할 메소드
    /// </summary>
    /// <returns>바라보고 있다면 true, 아니라면 false</returns>
    protected bool CheckDirection()
    {
        return GetDotProductToTarget() > detectionCosValue;
    }

    protected float GetDotProductToTarget()
    {
        Vector2 dirToTarget = (targetTransform.position - monsterTransform.position).normalized;

        return Vector3.Dot(dirToTarget, monsterTransform.right);
    }

    protected void OnDrawGizmosSelected()
    {
        if (monsterTransform == null) return;

        Vector3 pos = monsterTransform.position;
        float range = MonsterStatData.detectionRange;
        float angle = MonsterStatData.detectionAngle;

        DrawCircleGizmos(pos, range);
        DrawAngleGizmos(pos, angle, range);
    }

    private void DrawCircleGizmos(Vector3 monsterPos, float range)
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(monsterPos, range);
    }

    private void DrawAngleGizmos(Vector3 monsterPos, float angle, float range)
    {
        Gizmos.color = Color.red;
        Vector3 leftDir = AngleToVector(-angle * 0.5f);
        Vector3 rightDir = AngleToVector(angle * 0.5f);

        Gizmos.DrawLine(monsterPos, monsterPos + leftDir * range);
        Gizmos.DrawLine(monsterPos, monsterPos + rightDir * range);

        if (targetTransform != null && DetechTarget())
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(monsterPos, targetTransform.position);
        }
    }

    private Vector3 AngleToVector(float angleInDegrees)
    {
        angleInDegrees += transform.eulerAngles.z;

        return new Vector3(Mathf.Cos(angleInDegrees * Mathf.Deg2Rad),
                           Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0);
    }
}
