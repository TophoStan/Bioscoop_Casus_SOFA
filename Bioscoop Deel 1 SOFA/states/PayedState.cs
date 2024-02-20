using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bioscoop_Deel_1_SOFA.states;

public class PayedState : IState
{
    private Order _Order;
    public PayedState(Order order)
    {
        _Order = order;
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
        Console.WriteLine("Tickets are sent");
    }

    public void Submit()
    {
        throw new NotSupportedException();
    }
}
