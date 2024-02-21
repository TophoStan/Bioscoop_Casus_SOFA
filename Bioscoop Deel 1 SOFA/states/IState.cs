using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bioscoop_Deel_1_SOFA.states;
public interface IState
{
    void Cancel();
    
    void Pay();

    void Edit();
    
    void Submit();
    
    void Remind();

    void SendTickets();

}
