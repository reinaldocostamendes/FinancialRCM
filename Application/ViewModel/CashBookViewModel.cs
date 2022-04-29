using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel
{
    public class CashBookViewModel
    {
        public List<CashBook> Models { get; set; }
        public decimal Total { get; set; }  
    }
}
