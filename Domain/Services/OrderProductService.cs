using Domain.Interfaces;
using Domain.Services.Interfaces;
using Entities.Entities;
using Entities.PageParam;
using Entities.Validadors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class OrderProductService : IOrderProductService
    {
        private readonly IOrderProductRepository _orderProductRepository;

        public OrderProductService(IOrderProductRepository orderProductRepository)
        {
            _orderProductRepository = orderProductRepository;
        }

        public async Task AddOrderProduct(OrderProducts orderProducts)
        {
            var validator = new OrderProductValidator();
            var result = validator.Validate(orderProducts);
            if (!result.IsValid) { throw new Exception(); }
            await _orderProductRepository.AddOrderProduct(orderProducts);
        }

        public async Task Delete(OrderProducts entity)
        {
            await _orderProductRepository.Delete(entity);
        }

        public async Task DeleteOrderProduct(Guid Id)
        {
            var entity = await _orderProductRepository.GetById(Id);
            await _orderProductRepository.Delete(entity);
        }

        public async Task<List<OrderProducts>> GetAll(PageParameters pageParameters)
        {
            return await _orderProductRepository.GetAll(pageParameters);
        }

        public async Task<List<OrderProducts>> GetAllOrderProductsByOrderId(Guid Id)
        {
            return await _orderProductRepository.GetAllOrderProductsByOrderId(Id);
        }

        public async Task<OrderProducts> GetById(Guid id)
        {
            return await _orderProductRepository.GetById(id);
        }

        public async Task Post(OrderProducts entity)
        {
            await _orderProductRepository.Put(entity);
        }

        public async Task Put(OrderProducts entity)
        {
            await _orderProductRepository.Put(entity);
        }

        public async Task UpdateOrderProduct(OrderProducts orderProducts)
        {
            await _orderProductRepository.UpdateOrderProduct(orderProducts);
        }
    }
}