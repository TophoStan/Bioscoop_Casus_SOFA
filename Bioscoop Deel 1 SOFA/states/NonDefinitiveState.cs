using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bioscoop_Deel_1_SOFA.states;

public class NonDefinitiveState : IState
{

    private Order _Order;
    private Publisher _Publisher;

    public NonDefinitiveState(Order order, Publisher publisher)
    {
        _Order = order;
        _Publisher = publisher;
    }

    public void Cancel()
    {
        //Cancel
        string message = "Order cancelled";
        _Publisher.Notify(message);
    }

    public void Edit()
    {
        throw new NotSupportedException();
    }

    public void Pay()
    {
        throw new NotSupportedException();
    }

    public void Remind()
    {
        throw new NotSupportedException();
    }

    public void SendTickets()
    {
        throw new NotSupportedException();
    }

    public void Submit()
    {
        _Order.SetState(new ReservedState(_Order, _Publisher));
    }
}
