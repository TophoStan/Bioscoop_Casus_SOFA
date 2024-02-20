using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bioscoop_Deel_1_SOFA.states;

public class NonDefinitiveState : IState
{

    private Order _Order;

    public NonDefinitiveState(Order order)
    {
        _Order = order;
    }

    public void Cancel()
    {
        //Cancel
        Console.WriteLine("Order cancelled");
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
        Console.WriteLine("Order submitted");
        _Order.SetState(new ReservedState(_Order));
    }
}
