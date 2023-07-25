using System;
using System.Collections.Generic;

public class LevelStateMachine : StateMachine
{
    public Timer Timer { get; private set; }

    public LevelStateMachine(LevelInfo info)
    {
        States = new Dictionary<Type, State>()
        {
            [typeof(PreparationState)] = new PreparationState(this),
            [typeof(FightState)] = new FightState(this)
        };

        Timer = new Timer();
    }
}