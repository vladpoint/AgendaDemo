using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDemo
{
    public interface Login
    {
        Task<bool> Authenticate();
    }
}
