using UnityEngine;

public class Slime : BaseMonster
{
    private void Awake()
    {
        InitStateMachine();

        AddState();
    }

    protected override void AddState()
    {
        stateMachine.AddState(eState.Idle, new IdleState(this));

        stateMachine.AddState(eState.Trace, new TraceState(this));
    }

    private void Update()
    {
        stateMachine.Update();
    }
}
