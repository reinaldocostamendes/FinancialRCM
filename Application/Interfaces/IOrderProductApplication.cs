using Application.DTOs;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
   public interface IOrderProductApplication
    {
        Task AddOrderProduct(OrderProductDTO orderProducts);
    }
}
