using System;

/// <summary>
/// Condition 노드
/// 행동을 실행할지 말지를 판단하는 노드
/// </summary>
public class ConditionNode : Node
{
    private readonly Func<bool> predicate;

    public ConditionNode(string name, Func<bool> predicate) : base(name)
    {
        this.predicate = predicate;
    }

    public override eNodeStatus Tick()
    {
        bool result = predicate();

        if (result)
            return eNodeStatus.Success;

        return eNodeStatus.Failure;
    }
}