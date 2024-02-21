using Bioscoop_Deel_1_SOFA.subscribers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bioscoop_Deel_1_SOFA;

public class Publisher
{
    private List<ISubscriber> _subscribers = new List<ISubscriber>();

    public void Subscribe(ISubscriber subscriber)
    {
        _subscribers.Add(subscriber);
    }

    public void Unsubscribe(ISubscriber subscriber)
    {
        _subscribers.Remove(subscriber);
    }

    public void Notify(string message)
    {
        foreach (var subscriber in _subscribers)
        {
            subscriber.Notify(message);
        }
    }
}
