public interface IStateMachine
{
    public void SubscribeTransit(ITransition transition);
    public void UnsubscribeTransit(ITransition transition);
}