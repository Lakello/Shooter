using System;
using System.Collections.Generic;

public class LevelStateMachine : StateMachine
{
    public LevelStateMachine()
    {
        States = new Dictionary<Type, State>()
        {
            [typeof(InitializeLevelState)] = new InitializeLevelState(this)
        };
    }
}