using System.Collections.Generic;
using UnityEngine;

namespace BT
{
    public class BaseMonster : BTEntity
    {
        protected MonsterStatData monsterStatData;
        protected Transform monsterTransform;
        protected Transform targetTransform;

        protected float detectionCosValue;

        public void InitMonsterSetting(MonsterStatData monsterStatData)
        {
            this.monsterStatData = monsterStatData;
            detectionCosValue = Mathf.Cos(Mathf.Deg2Rad * monsterStatData.detectionAngle);

            BuildTree();
            monsterTransform = transform;
        }

        public void CacheTarget(Transform targetTransform)
        {
            this.targetTransform = targetTransform;
        }

        protected virtual void BuildTree()
        {
            Node attackNode = new Sequence("AttackNode", new List<Node>
            {
            new ConditionNode("AttackConditionNode", IsInAttackRange),
            new ActionNode("AttackActionNode", Attack)
            });

            Node traceNode = new Sequence("TraceNode", new List<Node>
            {
            new ConditionNode("TraceConditionNode", IsInDetectionRange),
            new ActionNode("TraceActionNode", Trace)
            });

            // 트리의 끝에 배치해서 어떤 조건도 걸리지 않으면 Idle로 행동 전환.
            Node idleNode = new ActionNode("IdleNode", Idle);

            // attack -> trace -> idle
            rootNode = new Selector("MonsterRootSelector", new List<Node>
            {
                attackNode,
                traceNode,
                idleNode
            });
        }

        protected bool IsInAttackRange()
        {
            return CheckAttackDistance();
        }

        protected bool IsInDetectionRange()
        {
            return CheckDetectionDistance() && CheckDirection();
        }

        protected eNodeStatus Attack()
        {
            return eNodeStatus.Running;
        }

        protected eNodeStatus Trace()
        {
            Vector2 moveDir = (targetTransform.position - monsterTransform.position).normalized;

            monsterTransform.Translate(moveDir * Time.deltaTime * monsterStatData.moveSpeed);

            return eNodeStatus.Running;
        }

        protected eNodeStatus Idle()
        {
            return eNodeStatus.Running;
        }

        protected bool CheckAttackDistance()
        {
            if (targetTransform == null) return false;

            float dist = Vector2.SqrMagnitude(targetTransform.position - monsterTransform.position);
            return dist < monsterStatData.attackRange * monsterStatData.attackRange;
        }

        protected bool CheckDetectionDistance()
        {
            if (targetTransform == null) return false;

            float dist = Vector2.SqrMagnitude(targetTransform.position - monsterTransform.position);
            return dist < monsterStatData.detectionRange * monsterStatData.detectionRange;
        }

        protected bool CheckDirection()
        {
            return GetDotProductToTarget() > detectionCosValue;
        }

        protected float GetDotProductToTarget()
        {
            Vector2 dirToTarget = (targetTransform.position - monsterTransform.position).normalized;

            return Vector3.Dot(dirToTarget, monsterTransform.right);
        }

    }
}
