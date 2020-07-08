using HoneyStore.Dto;
using HoneyStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace HoneyStore.Services
{
    public class CartsService
    {
        private readonly HoneyStoreContext _context;

        public CartsService(HoneyStoreContext context)
        {
            _context = context;
        }

        public ActionResult AddToCart(HoneyInTheCartDto honey, int clientId)
        {
            if (honey == null || !_context.Clients.Where(x => x.Id == clientId).Any())
                return new NotFoundResult();

            var cart = _context.HoneysInTheCart.Where(x => x.ClientId == clientId).ToList();
            bool isInTheCart = false;

            foreach (var honeyInCart in cart)
            {
                if(honey.Name == honeyInCart.Name)
                {
                    isInTheCart = true;
                    honeyInCart.Amount++;
                    _context.HoneysInTheCart.Update(honeyInCart);
                }
            }

            if (!isInTheCart)
            {
                _context.HoneysInTheCart.Add(new HoneyItem()
                {
                    Name = honey.Name,
                    Price = honey.Price,
                    Amount = honey.Amount,
                    ClientId = clientId
                });
            }


            _context.SaveChanges();

            return new OkResult();
        }

        public ActionResult RemoveItemFromCart(string honeyName)
        {
            var honey = _context.HoneysInTheCart.FirstOrDefault(x => x.Name == honeyName);

            if(honey == null)
                return new NotFoundResult();
            
            _context.HoneysInTheCart.Remove(honey);
            _context.SaveChanges();
            return new OkResult();
        }

        public ActionResult<CartDto> GetCart(int clientId)
        {

            var honeysInTheCart = _context.HoneysInTheCart.Where(x => x.ClientId == clientId).ToList();
            List<HoneyInTheCartDto> honeys = new List<HoneyInTheCartDto>();

            foreach (var honey in honeysInTheCart)
            {
                honeys.Add(new HoneyInTheCartDto()
                {   
                    Name = honey.Name,
                    Price = honey.Price,
                    Amount = honey.Amount
                });
            }

            return new CartDto()
            {
                Honeys = honeys
            };
        }
    }
}
