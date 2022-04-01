using System;

public class SubscriptionsWatcher
{
    public event Action Done;

    public int Count { get; private set; }
    
    public void Add()
    {
        Count++;
    }

    public void Remove()
    {
        Count--;

        if (Count < 0)
        {
            throw new Exception();
        }
        
        InvokeDoneIfNoneSubscribers();
    }

    public void InvokeDoneIfNoneSubscribers()
    {
        if (Count == 0)
        {
            OnDone();
        }
    }

    private void OnDone()
    {
        Done?.Invoke();
    }
}