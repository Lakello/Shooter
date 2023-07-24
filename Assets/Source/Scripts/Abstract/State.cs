public abstract class State
{
    protected StateMachine StateMachine;
        
    public abstract void Enter();
    public abstract void Exit();
}