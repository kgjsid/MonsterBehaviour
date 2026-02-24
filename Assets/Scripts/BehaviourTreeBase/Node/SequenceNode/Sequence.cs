using System.Collections.Generic;

/// <summary>
/// Sequence 노드
/// 여러 조건과 행동을 하나의 절차로 묶는 노드.
/// </summary>
public class Sequence : Node
{
    private readonly List<Node> children;

    public Sequence(string name, List<Node> children) : base(name)
    {
        this.children = children;
    }

    public override eNodeStatus Tick()
    {
        // 트리 구조에서 자식 노드를 위에서부터 순서대로 평가함.
        // Failure, Running이 나오면 즉시 탐색을 멈춤.
        for (int i = 0; i < children.Count; i++)
        {
            eNodeStatus status = children[i].Tick();

            if (status == eNodeStatus.Failure)
                return eNodeStatus.Failure;

            if (status == eNodeStatus.Running)
                return eNodeStatus.Running;
        }

        return eNodeStatus.Success;
    }
}