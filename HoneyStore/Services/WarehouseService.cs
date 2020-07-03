using HoneyStore.Dto;
using HoneyStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.Generic;
using System.Linq;

namespace HoneyStore.Services
{
    public class WarehouseService
    {
        private readonly HoneyStoreContext _context;

        public WarehouseService(HoneyStoreContext context)
        {
            _context = context;
        }

        public ActionResult AddHoney(HoneyItemDto honey)
        {
            if (honey == null)
                return new BadRequestResult();
            if (_context.HoneysInTheWarehouse.Where(x => x.Name == honey.Name).Any())
                return new ConflictResult();
            _context.HoneysInTheWarehouse.Add(new HoneyInTheWarehouse()
            {
                Name = honey.Name,
                Price = honey.Price,
                Amount = honey.Amount
            });
            _context.SaveChanges();
            return new OkResult();
        }

        public ActionResult RemoveHoney(int honeyId)
        {
            var honey = _context.HoneysInTheWarehouse.FirstOrDefault(x => x.Id == honeyId);

            if (honey == null)
                return new NotFoundResult();
            _context.HoneysInTheWarehouse.Remove(honey);
            _context.SaveChanges();
            return new OkResult();

        }

        public ActionResult<IEnumerable<HoneyInTheWarehouse>> GetAllHoneys()
        {
            return _context.HoneysInTheWarehouse;
        }

        public ActionResult<HoneyItemDto> GetHoney(int honeyId)
        {
            var honey = _context.HoneysInTheWarehouse.Where(x => x.Id == honeyId).FirstOrDefault();

            if (honey == null)
                return new NotFoundResult();

            return new HoneyItemDto()
            {
                Name = honey.Name,
                Price = honey.Price,
                Amount = honey.Amount
            };
        }
    }
}
