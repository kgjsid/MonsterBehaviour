using UnityEngine;
using System.Collections.Generic;
using System;

/// <summary>
/// 상태 패턴을 활용한 유한 상태 머신
/// </summary>
public class StateMachine
{
    private Dictionary<eState, BaseState> stateDic;
    private List<Transition> anyStateTransition;

    public eState CurState { get; private set; }

    private const string ENTER = "Enter";
    private const string EXIT = "Exit";
    private const string UPDATE = "Update";

    /// <summary>
    /// 생성자.
    /// 몬스터의 행동은 딕셔너리(enum, baseState)로 관리
    /// 전이(Transition) 구조체 리스트를 관리
    /// </summary>
    public StateMachine()
    {
        stateDic = new Dictionary<eState, BaseState>();
        anyStateTransition = new List<Transition>();
    }

    /// <summary>
    /// 행동머신에 상태 추가
    /// 중복된 상태는 허용하지 않음
    /// </summary>
    /// <param name="key"></param>
    /// <param name="state"></param>
    public void AddState(eState key, BaseState value)
    {
        stateDic.TryAdd(key, value);
    }

    /// <summary>
    /// 전이 조건을 추가
    /// </summary>
    /// <param name="start">현재 전이 상태</param>
    /// <param name="end">전이 목표 상태</param>
    /// <param name="condition">조건(리턴값이 bool인 메소드)</param>
    public void AddStateTransition(eState start, eState end, Func<bool> condition)
    {
        stateDic[start].Transitions.Add(new Transition(end, condition));
    }

    /// <summary>
    /// 어떤 상태에서든 바로 전이될 수 있는 조건을 추가
    /// </summary>
    /// <param name="state"></param>
    /// <param name="condition"></param>
    public void AddAnyStateTransition(eState state, Func<bool> condition)
    {
        anyStateTransition.Add(new Transition(state, condition));
    }
    
    /// <summary>
    /// 상태 머신 초기화
    /// </summary>
    /// <param name="entryState">시작될 상태</param>
    public void Init(eState entryState)
    {
        CurState = entryState;
        stateDic[entryState].Enter();
        StateDebug(stateDic[entryState].Owner.name, ENTER, entryState);
    }

    /// <summary>
    /// Update를 실행.
    /// 1. 현재 상태(State)의 Update
    /// 2. 전이 조건을 검사하여 상태 전이를 실행
    /// 2-1. 어떤 상태든지 전이할 상태 조건을 검사
    /// 2-2. 특정 상태 전이(Idle -> Trace, Trace -> Attack..)를 검사
    /// </summary>
    public void Update()
    {
        stateDic[CurState].Update();
        StateDebug(stateDic[CurState].Owner.name, UPDATE, CurState);

        foreach (var transition in anyStateTransition)
        {
            if(transition.condition())
            {
                ChangeState(transition.transitionState);
                return;
            }
        }

        foreach(var transition in stateDic[CurState].Transitions)
        {
            if(transition.condition())
            {
                ChangeState(transition.transitionState);
                return;
            }
        }
    }

    public void LateUpdate()
    {
        stateDic[CurState].LateUpdate();
    }

    public void FixedUpdate()
    {
        stateDic[CurState].FixedUpdate();
    }

    private void ChangeState(eState nextState)
    {
        stateDic[CurState].Exit();
        StateDebug(stateDic[CurState].Owner.name, EXIT, CurState);
        CurState = nextState;
        stateDic[CurState].Enter();
        StateDebug(stateDic[CurState].Owner.name, ENTER, CurState);
    }

    private void StateDebug(string name, string transition, eState state)
    {
        Debug.Log($"({name}) {transition} {state} state");
    }
}
