using UnityEngine;

public class Orc : BaseMonster
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

        stateMachine.AddStateTransition(eState.Idle, eState.Trace, () =>
        {
            return DetechTarget();
        });
        stateMachine.AddStateTransition(eState.Trace, eState.Idle, () =>
        {
            return !DetechTarget();
        });
    }
}
