using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterState 
{
    protected CharacterManagement _character;
    protected CharacterStateMachine _charStateMachine;

    public CharacterState(CharacterManagement character, CharacterStateMachine charStateMachine)
    {
        this._character = character;
        this._charStateMachine = charStateMachine;
    }
    public virtual void EnterState() { }
    public virtual void ExitState() { }
    public virtual void ChangeAnim() { }
}
