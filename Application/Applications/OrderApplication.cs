using Application.DTOs;
using Application.Interfaces;
using Application.ViewModel;
using AutoMapper;
using Domain.Interfaces;
using Domain.Services.Interfaces;
using Entities.Entities;
using Entities.Enums;
using Entities.PageParam;
using Entities.Validadors;
using Infrastruture.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Application.Applications
{
    public class OrderApplication : IOrderApplication
    {
        private readonly IOrderService _iorder;
        private readonly IOrderProductService _iorderProduct;
        private readonly IMapper _imapper;

        public OrderApplication(IOrderService iorder, IOrderProductService iorderProduc, IMapper imapper)
        {
            _iorder = iorder;
            _imapper = imapper;
            _iorderProduct = iorderProduc;
        }

        public async Task AddOrder(OrderDTO order)
        {
            var om = _imapper.Map(order, new Order());
            var totalAmount = order.OrderProducts.Sum(p => p.Value * p.Quantity);
            om.ProductsValues = totalAmount;
            om.TotalValue = totalAmount - order.Discount;
            om.Status = Entities.Enums.OrderStatus.RECEIVED;
            var g = Guid.NewGuid();
            om.Id = g;
            var custumizedList = custumizedListOrderProduct(order.OrderProducts.ToList(), g);
            var validator = new OrderValidator();
            var result = validator.Validate(om);
            if (!result.IsValid)
            {
                var message = "";
                foreach (var item in result.Errors)
                {
                    message += item.ToString() + "\n";
                }
                throw new Exception(message);
            }

            if (ContainDiferentsCategory(custumizedList))
            {
                throw new Exception("Order contain fisical and digital products");
            }
            if (ContainEqualProduts(custumizedList))
            {
                throw new Exception("Order contain 2 or more equals products");
            }
            var orderValidator = new OrderValidator();
            var resultOrder = orderValidator.Validate(om);
            if (!resultOrder.IsValid) { throw new Exception(); }
            await _iorder.AddOrder(om);
            foreach (var custumized in custumizedList)
            {
                var orderProductValidator = new OrderProductValidator();
                var resultorderProduct = orderProductValidator.Validate(custumized);
                if (!resultorderProduct.IsValid) { throw new Exception(); }
                await _iorderProduct.AddOrderProduct(custumized);
            }
        }

        private bool ContainDiferentsCategory(List<OrderProducts> products)
        {
            if (products == null || products.Count > 1)
            {
                var product = products[0];
                for (int i = 1; i < products.Count; i++)
                {
                    var p = products[i];
                    if ((p != null && product != null) && (p.ProductCategory != product.ProductCategory)) { return true; }
                    else
                    {
                        product = products[i];
                    }
                }
            }

            return false;
        }

        private List<OrderProducts> custumizedListOrderProduct(List<OrderProductDTO> oderproducts, Guid id)
        {
            List<OrderProducts> products = new List<OrderProducts>();
            foreach (var oderproduct in oderproducts)
            {
                OrderProducts op = new OrderProducts();
                op.ProductDescription = oderproduct.ProductDescription;
                op.Quantity = oderproduct.Quantity;
                op.OrderId = id;
                op.Id = Guid.NewGuid();
                op.ProductId = Guid.NewGuid();
                op.Value = oderproduct.Value;
                op.Total = op.Quantity * op.Value;
                op.ProductCategory = (Entities.Enums.ProductCategory)oderproduct.ProductCategory;
                products.Add(op);
            }
            return products;
        }

        private bool ContainEqualProduts(List<OrderProducts> products)
        {
            if (products == null || products.Count > 1)
            {
                var product = products[0];
                for (int i = 1; i < products.Count; i++)
                {
                    var p = products[i];
                    if ((p != null && product != null) && (p.ProductCategory == product.ProductCategory && p.ProductDescription == product.ProductDescription
                        )) { return true; }
                    else
                    {
                        product = products[i];
                    }
                }
            }

            return false;
        }

        public async Task DeleteOrder(Guid id)
        {
            // await _iorder.DeleteOrder(id);
            var om = await _iorder.GetByIdOrder(id);

            if (om == null) { throw new Exception("Order not exist"); }
            if (om.Status == Entities.Enums.OrderStatus.FINISHED)
            {
                string apiUrl = "https://localhost:5001/api/CashBooks";

                var client = new HttpClient();

                var odto = new CashBookDTO();
                odto.Origin = 1;
                odto.OriginId = om.Id;
                odto.Description = "Purshase order Nº " + om.Code;
                odto.Value = om.TotalValue;
                odto.Type = 3;
                // var jsonObject = Newtonsoft.Json.JsonConvert.SerializeObject(odto);

                var response = await client.PostAsJsonAsync(apiUrl, odto);
                if (response != null && !response.IsSuccessStatusCode)
                {
                    // var result = JsonSerializer.Deserialize<string>(response.Content.)
                    throw new Exception("Error to put cashbook! " + response.ToString());
                }
                else
                {
                    om.Status = Entities.Enums.OrderStatus.FINISHED;
                    await _iorder.DeleteOrder(id);
                }
            }
            else
            {
                await _iorder.DeleteOrder(id);
            }
        }

        public async Task<List<Order>> GetAllOrders(PageParameters pageParameters)
        {
            return await _iorder.GetAllOrders(pageParameters);
        }

        public async Task<Order> GetOrdersByCode(long code)
        {
            return await _iorder.GetOrdersByCode(code);
        }

        public async Task<Order> GetOrdersByClient(Guid id)
        {
            return await _iorder.GetOrdersByClientId(id);
        }

        public async Task UpdateOrder(OrderViewModel order)
        {
            var o = await _iorder.GetByIdOrder(order.Id);
            if (o == null)
            {
                throw new Exception("This Order not exists!");
            }
            if (o.Status == Entities.Enums.OrderStatus.FINISHED)
            {
                throw new Exception("This Order is concluded!");
            }
            var validator = new OrderValidator();
            var result = validator.Validate(o);
            var om = new Order();
            var orderToUpdate = _imapper.Map(order, om);
            var totalAmount = order.OrderProducts.Sum(p => p.Value * p.Quantity);
            orderToUpdate.TotalValue = totalAmount;

            foreach (var custumized in order.OrderProducts)
            {
                var orderProductValidator = new OrderProductValidator();
                var resultorderProduct = orderProductValidator.Validate(custumized);
                if (!resultorderProduct.IsValid) { throw new Exception(); }
                if (_iorderProduct.GetAllOrderProductsByOrderId(o.Id).Result.Contains(custumized))
                {
                    custumized.Total = custumized.Value * custumized.Quantity;
                    await _iorderProduct.AddOrderProduct(custumized);
                }
                else
                {
                    custumized.Total = custumized.Value * custumized.Quantity;
                    await _iorderProduct.UpdateOrderProduct(custumized);
                }
            }

            if (!result.IsValid)
            {
                var message = "";
                foreach (var item in result.Errors)
                {
                    message += item.ToString() + "\n";
                }
                throw new Exception(message);
            }
            string apiUrl = "https://localhost:5001/api/CashBooks";

            var client = new HttpClient();

            var odto = new CashBookDTO()
            {
                Origin = 1,
                OriginId = order.Id,
                Description = "Updated Purshase order Nº " + order.Code,
                Value = orderToUpdate.TotalValue - o.TotalValue,
                Type = ((orderToUpdate.TotalValue - o.TotalValue) > 0) ? 2 : 1
            };

            // var jsonObject = Newtonsoft.Json.JsonConvert.SerializeObject(odto);

            var response = await client.PostAsJsonAsync(apiUrl, odto);
            if (response != null && !response.IsSuccessStatusCode)
            {
                // var result = JsonSerializer.Deserialize<string>(response.Content.)
                throw new Exception("Error to put cashbook! " + response.ToString());
            }
            else
            {
                await _iorder.UpdateOrder(orderToUpdate);
            }
        }

        public async Task UpdateOrderStatus(Guid id, OrderStatus orderStatus)
        {
            var om = await _iorder.GetById(id);
            var validator = new OrderValidator();
            var result = validator.Validate(om);
            if (!result.IsValid)
            {
                var message = "";
                foreach (var item in result.Errors)
                {
                    message += item.ToString() + "\n";
                }
                throw new Exception(message);
            }
            var products = _iorderProduct.GetAllOrderProductsByOrderId(id);

            var p = products.Result.Where(p => p.ProductCategory == Entities.Enums.ProductCategory.FISICAL);
            if (p.Count() > 0 && om.Status == Entities.Enums.OrderStatus.WAITING_DOWNLOAD)
            {
                throw new Exception("Not allowed to change fisical product to waiting download!");
            }
            var p2 = products.Result.Where(p => p.ProductCategory == Entities.Enums.ProductCategory.DIGITAL);
            if (p2.Count() > 0 && om.Status == Entities.Enums.OrderStatus.WAITING_DELIVERY)
            {
                throw new Exception("Not allowed to change Digital product to waiting Delivery!");
            }

            if (om.Status == Entities.Enums.OrderStatus.FINISHED)
            {
                throw new Exception("Not allowed to change finished status!");
            }
            if (orderStatus == Entities.Enums.OrderStatus.RECEIVED)
            {
                om.Status = Entities.Enums.OrderStatus.RECEIVED;
                await _iorder.UpdateOrder(om);
            }
            if (orderStatus == Entities.Enums.OrderStatus.WAITING_DELIVERY)
            {
                om.Status = Entities.Enums.OrderStatus.WAITING_DELIVERY;
                await _iorder.UpdateOrder(om);
            }
            if (orderStatus == Entities.Enums.OrderStatus.WAITING_DOWNLOAD)
            {
                om.Status = Entities.Enums.OrderStatus.WAITING_DOWNLOAD;
                await _iorder.UpdateOrder(om);
            }
            if (orderStatus == Entities.Enums.OrderStatus.FINISHED)
            {
                string apiUrl = "https://localhost:5001/api/CashBooks";

                var client = new HttpClient();

                var odto = new CashBookDTO()
                {
                    Origin = 1,
                    OriginId = om.Id,
                    Description = "Purshase order Nº " + om.Code,
                    Value = -om.TotalValue,
                    Type = 1
                };

                // var jsonObject = Newtonsoft.Json.JsonConvert.SerializeObject(odto);

                var response = await client.PostAsJsonAsync(apiUrl, odto);
                if (response != null && !response.IsSuccessStatusCode)
                {
                    // var result = JsonSerializer.Deserialize<string>(response.Content.)
                    throw new Exception("Error to put cashbook! " + response.ToString());
                }
                else
                {
                    om.Status = Entities.Enums.OrderStatus.FINISHED;
                    await _iorder.UpdateOrder(om);
                }
            }
        }
    }
}