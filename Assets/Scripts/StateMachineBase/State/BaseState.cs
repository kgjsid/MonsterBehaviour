using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 베이스 상태. 상태들의 부모 클래스.
/// Enter, Update, LateUpdate, FixedUpdate, Exit를 각 자식에서 재정의해서 사용
/// </summary>
public class BaseState
{
    protected List<Transition> transitions;
    protected StateEntity owner;

    public List<Transition> Transitions
    {
        get
        {
            return transitions;
        }
    }

    public StateEntity Owner { get { return owner; } }

    public BaseState(StateEntity owner)
    {
        transitions = new List<Transition>();
        this.owner = owner;
    }

    public virtual void Enter() { }
    public virtual void Update() { }
    public virtual void LateUpdate() { }
    public virtual void FixedUpdate() { }
    public virtual void Exit() { }
}
