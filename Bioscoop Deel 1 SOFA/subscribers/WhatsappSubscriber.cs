using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bioscoop_Deel_1_SOFA.subscribers;

public class WhatsappSubscriber : ISubscriber
{
    public void Notify(string message)
    {
        Console.WriteLine("Whatsapp message sent with message: ");
        Console.WriteLine(message);
    }
}

