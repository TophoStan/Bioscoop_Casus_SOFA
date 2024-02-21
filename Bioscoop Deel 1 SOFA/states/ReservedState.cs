using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bioscoop_Deel_1_SOFA.states;

public class ReservedState : IState
{

    private Order _Order;
    private Publisher _Publisher;

    public ReservedState(Order order, Publisher publisher)
    {
        _Order = order;
        _Publisher = publisher;
        //If 12 hours before screening date,
        if (order.tickets[0].GetScreeningDate() < DateTime.Now.AddHours(24))
        {
            _Order.SetState(new ProvisionalState(_Order, _Publisher));
        }
    }

    public void Cancel()
    {
        string message = "Order cancelled";
        _Publisher.Notify(message);
        _Order.SetState(new NonDefinitiveState(_Order, _Publisher));
    }

    public void Edit()
    {
        Console.WriteLine("Order edited");
    }

    public void Pay()
    {
        _Order.SetState(new PayedState(_Order, _Publisher));
    }

    public void Remind()
    {
        throw new NotImplementedException();
    }

    public void SendTickets()
    {
        throw new NotImplementedException();
    }

    public void Submit()
    {
        throw new NotImplementedException();
    }
}
