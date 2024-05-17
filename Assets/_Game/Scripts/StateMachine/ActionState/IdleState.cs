using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : CharacterState
{
    public IdleState(CharacterManagement character, CharacterStateMachine charStateMachine) : base(character, charStateMachine)
    {
    }

    public override void ChangeAnim()
    {
        base.ChangeAnim();
    }

    public override void EnterState()
    {
        base.EnterState();
    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
