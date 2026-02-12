using UnityEngine;

/// <summary>
/// BaseMonster Å¬·¡½º.
/// </summary>
public class BaseMonster : StateEntity
{
    private void Awake()
    {
        InitStateMachine();
    }

    protected virtual bool CheckPlayer()
    {
        return false;
    }
}
