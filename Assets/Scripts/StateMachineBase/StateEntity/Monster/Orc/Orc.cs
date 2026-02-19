using UnityEngine;

public class Orc : BaseMonster
{
    public override void InitMonsterSetting(MonsterStatData monsterStatData)
    {
        InitStateMachine();
        base.InitMonsterSetting(monsterStatData);
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

    private void Update()
    {
        // stateMachine.Update();
    }
}
