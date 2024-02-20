using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bioscoop_Deel_1_SOFA.states;

public class ReservedState : IState
{

    private Order _Order;
    public ReservedState(Order order)
    {
        _Order = order;
        //If 12 hours before screening date,
        if (order.tickets[0].GetScreeningDate() < DateTime.Now.AddHours(24))
        {
            _Order.SetState(new ProvisionalState(_Order));
        }
    }

    public void Cancel()
    {
        Console.WriteLine("Order Canceled");
        _Order.SetState(new NonDefinitiveState(_Order));
    }

    public void Edit()
    {
        Console.WriteLine("Order edited");
    }

    public void Pay()
    {
        Console.WriteLine("Order is payed");
        _Order.SetState(new PayedState(_Order));
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
