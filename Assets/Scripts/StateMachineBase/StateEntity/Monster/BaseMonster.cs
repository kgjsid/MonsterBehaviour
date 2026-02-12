using UnityEngine;

/// <summary>
/// BaseMonster 클래스. 
/// 모든 몬스터가 상속받아 사용할 부모 클래스.
/// </summary>
public class BaseMonster : StateEntity
{
    protected GameObject targetObject;

    private void Awake()
    {
        InitStateMachine();
    }

    protected virtual bool CheckPlayer()
    {
        return CheckDistance() && CheckDirection();
    }

    /// <summary>
    /// 거리 측정용 메소드
    /// </summary>
    /// <returns>가깝다면 true, 멀다면 false</returns>
    protected bool CheckDistance()
    {
        return false;
    }

    /// <summary>
    /// target을 바라보고 있는 방향을 체크할 메소드
    /// </summary>
    /// <returns>바라보고 있다면 true, 아니라면 false</returns>
    protected bool CheckDirection()
    {
        return false;
    }
}
