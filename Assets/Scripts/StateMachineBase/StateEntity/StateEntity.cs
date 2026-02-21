using UnityEditor.Rendering;
using UnityEngine;

/// <summary>
/// 상태 머신을 가지고 있을 클래스의 최상위.
/// </summary>
public class StateEntity : MonoBehaviour
{
    protected StateMachine stateMachine;

    private void Awake()
    {
        InitStateMachine();
    }

    private void Update()
    {
        UpdateStateMachine();
    }

    private void LateUpdate()
    {
        LateUpdateStateMachine();
    }

    private void FixedUpdate()
    {
        FixedUpdateStateMachine();
    }

    public void StartStateMachine(eState enterState = eState.Idle)
    {
        stateMachine.Init(enterState);
    }

    protected virtual void InitStateMachine()
    {
        stateMachine = new StateMachine();
    }

    protected virtual void AddState()
    {

    }

    protected virtual void UpdateStateMachine()
    {
        stateMachine.Update();
    }

    protected virtual void LateUpdateStateMachine()
    {
        stateMachine.LateUpdate();
    }

    protected virtual void FixedUpdateStateMachine()
    {
        stateMachine.FixedUpdate();
    }
}
