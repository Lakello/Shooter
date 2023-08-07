public interface ITransitable
{
    public void SubscribeTransit(Transition transition);
    public void UnsubscribeTransit(Transition transition);
}