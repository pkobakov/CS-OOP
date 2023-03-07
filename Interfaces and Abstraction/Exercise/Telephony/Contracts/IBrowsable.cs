using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telephony.Contracts
{
    public interface IBrowsable
    {
        string Browse(string url);
    }
}
