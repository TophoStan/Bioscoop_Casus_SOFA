using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bioscoop_Deel_1_SOFA.states;

public class PayedState : IState
{
    private Order _Order;
    private Publisher _Publisher;

    public PayedState(Order order, Publisher publisher)
    {
        _Order = order;
        _Publisher = publisher;

        string message = "Order payed";
        _Publisher.Notify(message);
    }

    public void Cancel()
    {
        throw new NotSupportedException();
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
        //Cool
        string message = "Tickets are sent";
        _Publisher.Notify(message);
    }

    public void Submit()
    {
        throw new NotSupportedException();
    }
}
