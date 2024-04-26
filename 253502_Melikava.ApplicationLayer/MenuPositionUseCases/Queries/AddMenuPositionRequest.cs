using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253502_Melikava.ApplicationLayer.MenuPositionUseCases.Queries
{
    public sealed record AddMenuPositionRequest(string type,string name,double price):IRequest<MenuPosition>
    {
    }
}
