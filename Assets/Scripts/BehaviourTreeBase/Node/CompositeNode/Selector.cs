using System.Collections.Generic;

/// <summary>
/// Selector 노드
/// 여러 행동 중에서 지금 실행할 행동을 고르는 역할을 함.
/// </summary>
public class Selector : Node
{
    private readonly List<Node> children;

    public Selector(string name, List<Node> children) : base(name)
    {
        this.children = children;
    }

    public override eNodeStatus Tick()
    {
        // 트리 구조에서 자식 노드를 위에서부터 순서대로 평가함.
        // Success, Running이 나오면 즉시 탐색을 멈춤.
        for (int i = 0; i < children.Count; i++)
        {
            eNodeStatus status = children[i].Tick();

            if(status == eNodeStatus.Success)
                return eNodeStatus.Success;
            
            if (status == eNodeStatus.Running)
                return eNodeStatus.Running;
        }

        return eNodeStatus.Failure;
    }
}