/// <summary>
/// 노드 클래스
/// 모든 노드들의 최상위 클래스.
/// </summary>
public abstract class Node
{
    private string name;

    public string Name { get; }

    protected Node(string name)
    {
        this.name = name;
    }

    public abstract eNodeStatus Tick();
}