using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel
{
   public class OrderStatusViewModel
    {
        public Guid Id { get; set; }
        public OrderStatus Status { get; set; }
    }
}
