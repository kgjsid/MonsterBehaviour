using System;

/// <summary>
/// 상태 전이에 대한 정보를 포함할 구조체
/// </summary>
public struct Transition
{
    public eState transitionState;
    public Func<bool> condition;

    public Transition(eState transitionState, Func<bool> condition)
    {
        this.transitionState = transitionState;
        this.condition = condition;
    }
}