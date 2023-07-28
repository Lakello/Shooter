using System;

public interface ITransition
{
    public abstract event Action NeedTransit;
}