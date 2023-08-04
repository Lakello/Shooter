using System;

public interface ITransition
{
    public abstract event Action<IState> NeedTransit;

    public abstract void OnEnable();
    public abstract void OnDisable();
}