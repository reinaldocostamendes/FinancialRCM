using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class CashBook
    {
        public Guid Id { get; set; } 
        public CashBookOrigin? Origin { get; set; }   
        
        public Guid? OriginId { get; set; }

        public string Description { get; set; }
        public CashBookType Type { get; set; }  
        public decimal Value { get; set; }
    }
}
