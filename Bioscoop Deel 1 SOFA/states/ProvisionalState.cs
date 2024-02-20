using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bioscoop_Deel_1_SOFA.states;

public class ProvisionalState : IState
{
    private Order _Order;
    public ProvisionalState(Order order)
    {
        _Order = order;
        Remind();

        if (order.tickets[0].GetScreeningDate() < DateTime.Now.AddHours(12))
        {
            Console.WriteLine("Order has not been payed");
            Cancel();
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
        Remind();
    }

    public void Pay()
    {
        _Order.SetState(new PayedState(_Order));
    }

    public void Remind()
    {
        Console.WriteLine("REMINDER: Order is not yet payed");
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
