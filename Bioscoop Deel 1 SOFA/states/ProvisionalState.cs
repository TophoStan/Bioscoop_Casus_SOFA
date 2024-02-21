using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bioscoop_Deel_1_SOFA.states;

public class ProvisionalState : IState
{
    private Order _Order;
    private Publisher _Publisher;

    public ProvisionalState(Order order, Publisher publisher)
    {
        _Order = order;
        _Publisher = publisher;
        Remind();

        if (order.tickets[0].GetScreeningDate() < DateTime.Now.AddHours(12))
        {
            string message = "Payment deadline has been passed";
            _Publisher.Notify(message);
            Cancel();
        }
    }

    public void Cancel()
    {
        string message = "Order has been cancelled";
        _Publisher.Notify(message);
        _Order.SetState(new NonDefinitiveState(_Order, _Publisher));
    }

    public void Edit()
    {
        Console.WriteLine("Order edited");
        Remind();
    }

    public void Pay()
    {
        _Order.SetState(new PayedState(_Order, _Publisher));
    }

    public void Remind()
    {
        string message = "REMINDER: Order is not yet payed";
        _Publisher.Notify(message);
    }

    public void SendTickets()
    {
        throw new NotSupportedException();
    }

    public void Submit()
    {
        throw new NotSupportedException();
    }
}
