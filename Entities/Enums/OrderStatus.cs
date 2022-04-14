using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Enums
{
   public enum OrderStatus
    {
        RECEIVED=1,
        WAITING_DELIVERY=2,
        WAITING_DOWNLOAD=3,
        FINISHED=4
    }
}
