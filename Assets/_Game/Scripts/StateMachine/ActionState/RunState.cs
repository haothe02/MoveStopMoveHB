using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : CharacterState
{
    public RunState(CharacterManagement character, CharacterStateMachine charStateMachine) : base(character, charStateMachine)
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
