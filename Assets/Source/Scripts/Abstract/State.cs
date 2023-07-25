public abstract class State
{
    protected StateMachine StateMachine;

    public State(StateMachine stateMachine)
    {
        StateMachine = stateMachine;
    }

    public abstract void Enter();
    public abstract void Exit();
}