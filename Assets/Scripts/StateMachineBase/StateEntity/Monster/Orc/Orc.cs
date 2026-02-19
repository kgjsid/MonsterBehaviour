using UnityEngine;

public class Orc : BaseMonster
{
    private void Awake()
    {
        InitStateMachine();
        InitMonsterSetting();
        AddState();
    }

    // 1. Player 캐싱 -> 아마 매니저에서 캐싱?
    // 2. Monster 스폰 방식으로 변경 -> 매니저 따로 생성(풀도 일단 임시로 만들어두기)
    // 후에 bt, fsm 비교를 위한 구조도 고민
    // 일단 MonsterManager를 따로 생성 -> 여기에서, BaseMonster를 들고 있는 건 맞는 것 같음.
    // 생성 풀 만들어두고 쓰자. 일단은. 그런데 나중에 namespace를 분리해서 bt기반인지, fsm 기반인지 바꿔보자
    // 3. Monster 이동 등 State 완성

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
