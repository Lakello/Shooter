using Zenject;

public abstract class State
{
    protected StateMachine LevelStateMachine;

    public abstract void Enter();
    public abstract void Exit();

    [Inject]
    private void Init(StateMachine stateMachine)
    {
        LevelStateMachine = stateMachine;
    }
}
