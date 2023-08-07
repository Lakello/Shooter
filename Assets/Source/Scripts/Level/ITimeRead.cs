internal interface ITimeRead
{
    public float RemainingTime { get; }

    public event System.Action TimeIsUp;
}
