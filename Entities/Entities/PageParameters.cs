using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.PageParam
{
    public class PageParameters
    {
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = int.MaxValue;
    }
}
