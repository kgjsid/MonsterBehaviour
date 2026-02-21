using System.Collections.Generic;
using UnityEngine;

public class BTEntity : MonoBehaviour
{
    private Node rootNode;

    private void Start()
    {
        rootNode = BuildTree();
    }

    private void Update()
    {
        rootNode.Tick();
    }

    private Node BuildTree()
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

        Node idleNode = new Sequence("IdleNode", new List<Node>
        {
            new ConditionNode("IdleConditionNode", IsEnterIdleStatus),
            new ActionNode("IdleActionNode", Idle)
        });

        return null;
    }

    private bool IsInAttackRange()
    {
        return false;
    }

    private bool IsInDetectionRange()
    {
        return false;
    }

    private bool IsEnterIdleStatus()
    {
        return true;
    }

    private eNodeStatus Attack()
    {
        return eNodeStatus.Failure;
    }

    private eNodeStatus Trace()
    {
        return eNodeStatus.Failure;
    }

    private eNodeStatus Idle()
    {
        return eNodeStatus.Failure;
    }

}
