﻿using HoneyStore.Dto;
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

            _context.HoneysInTheCart.Add(new HoneyItem()
            {
                Name = honey.Name,
                Price = honey.Price,
                ClientId = clientId,
            });

            _context.SaveChanges();

            return new OkResult();
        }

        public ActionResult RemoveItemFromCart(int honeyId)
        {
            var honey = _context.HoneysInTheCart.FirstOrDefault(x => x.Id == honeyId);

            if(honey == null)
                return new NotFoundResult();
            
            _context.HoneysInTheCart.Remove(honey);
            _context.SaveChanges();
            return new OkResult();
        }

        public ActionResult<CartDto> GetCart(int clientId)
        {
            if (!_context.HoneysInTheCart.Where(x => x.ClientId == clientId).Any())
            {
                return new NotFoundResult();
            }

            var honeysInTheCart = _context.HoneysInTheCart.Where(x => x.ClientId == clientId).ToList();
            List<HoneyInTheCartDto> honeys = new List<HoneyInTheCartDto>();

            foreach (var honey in honeysInTheCart)
            {
                honeys.Add(new HoneyInTheCartDto()
                {   Id = honey.Id,
                    Name = honey.Name,
                    Price = honey.Price
                });
            }

            return new CartDto()
            {
                Honeys = honeys
            };
        }
    }
}
