using HoneyStore.Dto;
using HoneyStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace HoneyStore.Services
{
    public class OrdersService
    {
        private readonly HoneyStoreContext _context;

        public OrdersService(HoneyStoreContext context)
        {
            _context = context;
        }

        public ActionResult<OrderDto> GetOrder(int orderId)
        {
            var _order = _context.Orders.FirstOrDefault(x => x.Id == orderId);
            if (_order == null)
                return new NotFoundResult();

            List<HoneyItemDto> orderedHoneys = new List<HoneyItemDto>();

            foreach (var honey in _context.OrderedHoneys.Where(x => x.OrderId == _order.Id))
            {
                orderedHoneys.Add(new HoneyItemDto()
                {
                    Name = honey.Name,
                    Price = honey.Price,
                    Amount = honey.Amount
                });
            }

            OrderDto order = new OrderDto()
            {
                Id = _order.Id,
                ClientId = _order.ClientId,
                OrderedHoneys = orderedHoneys,
                TotalPrice = _order.TotalPrice,
                Delivery = _order.Delivery,
                Payment = _order.Payment,
                Status = _order.Status,
                Date = _order.Date
            }; 

            return order;
        }

        public ActionResult<IEnumerable<OrderDto>> GetOrders(Status status, bool all)
        {
            List<Order> _orders;

            if (all)
                _orders = _context.Orders.ToList();
            else
                _orders = _context.Orders.Where(x => x.Status == status).ToList();

            List<OrderDto> orders = new List<OrderDto>();

            foreach (var order in _orders)
            {
                List<HoneyItemDto> orderedHoneys = new List<HoneyItemDto>();

                foreach (var honey in _context.OrderedHoneys.Where(x => x.OrderId == order.Id))
                {
                    orderedHoneys.Add(new HoneyItemDto()
                    {
                        Name = honey.Name,
                        Price = honey.Price,
                        Amount = honey.Amount
                    });
                }

                orders.Add(new OrderDto()
                {
                    Id = order.Id,
                    ClientId = order.ClientId,
                    OrderedHoneys = orderedHoneys,
                    TotalPrice = order.TotalPrice,
                    Delivery = order.Delivery,
                    Payment = order.Payment,
                    Status = order.Status,
                    Date = order.Date
                });
            }

            return orders;
        }

        public ActionResult NewOrder(OrderDto order)
        {
            if (order == null)
                return new BadRequestResult();

            if (!_context.Clients.Any(x => x.Id == order.ClientId))
                return new NotFoundResult();

            List<OrderedHoney> orderedHoneys = new List<OrderedHoney>();

            foreach (var honey in order.OrderedHoneys)
            {
                //check if is in the warehouse
                int amountInWarehouse = _context.HoneysInTheWarehouse.Where(x => x.Name == honey.Name).FirstOrDefault().Amount;
                if (amountInWarehouse - honey.Amount < 0)
                    return new ConflictResult();

                orderedHoneys.Add(new OrderedHoney()
                {
                    Name = honey.Name,
                    Price = honey.Price,
                    Amount = honey.Amount
                });
            }

            Order newOrder = new Order()
            {
                ClientId = order.ClientId,
                OrderedHoneys = orderedHoneys,
                TotalPrice = order.TotalPrice,
                Delivery = order.Delivery,
                Payment = order.Payment,
                Status = Status.New,
                Date = order.Date
            };

            _context.Orders.Add(newOrder);
            _context.SaveChanges();

            UpdateWarehouse(-1, newOrder.Id);

            return new OkResult();
        }

        public ActionResult SendTheOrder(int orderId)
        {
            var order = _context.Orders.FirstOrDefault(x => x.Id == orderId);

            if (order == null)
                return new NotFoundResult();

            order.Status = Status.Shipped;
            _context.Orders.Update(order);
            _context.SaveChanges();

            return new OkResult();

        }

        public ActionResult ConfirmDelivery(int orderId)
        {

            var order = _context.Orders.FirstOrDefault(x => x.Id == orderId);

            if (order == null)
                return new NotFoundResult();

            order.Status = Status.Delivered;
            _context.Orders.Update(order);
            _context.SaveChanges();

            return new OkResult();
        }

        public ActionResult CancelTheOrder(int orderId)
        {
            var order = _context.Orders.FirstOrDefault(x => x.Id == orderId);

            UpdateWarehouse(1, orderId);

            if (order == null)
                return new NotFoundResult();
            if (order.Status != Status.New)
                return new ConflictResult();

            _context.Orders.Remove(order);
            _context.SaveChanges();

            return new OkResult();
        }

        private void UpdateWarehouse(sbyte sign, int orderId)
        {
            List<OrderedHoney> orderedHoneys = _context.OrderedHoneys.Where(x => x.OrderId == orderId).ToList();

            WarehouseService warehouseService = new WarehouseService(_context);
            foreach (var honey in orderedHoneys)
            {
                warehouseService.UpdateAmountOfHoney(honey.Name, sign * honey.Amount);
            }
        }
    }
}
