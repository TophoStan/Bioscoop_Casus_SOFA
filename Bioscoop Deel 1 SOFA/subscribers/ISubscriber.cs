using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bioscoop_Deel_1_SOFA.subscribers;

public interface ISubscriber
{
    void Notify(string message);
}
