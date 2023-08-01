using System;

public interface IState
{
    public abstract event Action Enable;
    public abstract event Action Disable;
    public abstract void Enter();
    public abstract void Exit();
} 