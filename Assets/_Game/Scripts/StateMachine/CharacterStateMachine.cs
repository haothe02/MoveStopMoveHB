using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStateMachine
{
    public CharacterState _currentSate { get; set; }    
    
    public void Initialize(CharacterState characterState)
    {
        _currentSate = characterState;
        _currentSate.EnterState();
    }
    public void ChangeSate(CharacterState newState)
    {
        _currentSate.ExitState();
        _currentSate = newState;
        _currentSate.EnterState();
    }
}
