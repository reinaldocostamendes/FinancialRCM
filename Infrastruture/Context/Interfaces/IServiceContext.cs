using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastruture.Context.Interfaces
{
    public interface IServiceContext
    {
        IReadOnlyCollection<string> Notifications { get; }

        bool HasNotification();

        void AddNotification(string message);
    }
}
