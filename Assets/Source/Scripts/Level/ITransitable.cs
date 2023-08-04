public interface ITransitable
{
    public void SubscribeTransit(ITransition transition);
    public void UnsubscribeTransit(ITransition transition);
}