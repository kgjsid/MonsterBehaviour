using UnityEngine;

public class Orc : BaseMonster
{
    private void Awake()
    {
        InitStateMachine();
        InitMonsterSetting();
        AddState();
    }

    protected override void InitMonsterSetting()
    {
        base.InitMonsterSetting();

        MonsterStatData = new MonsterStatData("Orc", 200, 20, 5f, 30f, 1f, 5);
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

    private void Update()
    {
        stateMachine.Update();
    }
}
