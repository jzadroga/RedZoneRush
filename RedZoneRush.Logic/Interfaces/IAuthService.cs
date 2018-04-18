using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedZoneRush.Logic.Interfaces
{
    public interface IAuthService
    {
        string SendToken(string phoneNumber);
    }
}
