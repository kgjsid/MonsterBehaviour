using System;

/// <summary>
/// Action 노드
/// 실제 행동을 수행하고 상태를 반환하는 노드
/// </summary>
public class ActionNode : Node
{
    private readonly Func<eNodeStatus> action;

    public ActionNode(string name, Func<eNodeStatus> action) : base(name)
    {
        this.action = action;
    }

    public override eNodeStatus Tick()
    {
        return action();
    }
}