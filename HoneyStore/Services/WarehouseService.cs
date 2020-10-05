using HoneyStore.Dto;
using HoneyStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.Generic;
using System.IO;
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

        public IActionResult AddHoney(HoneyInTheWarehouseDto honey)
        {
            if (honey == null)
                return new BadRequestResult();
           
            if (_context.HoneysInTheWarehouse.Where(x => x.Name == honey.Name).Any())
            {
                File.Delete(honey.ImgPath);
                return new ConflictResult();
            }
            _context.HoneysInTheWarehouse.Add(new HoneyInTheWarehouse()
            {
                Name = honey.Name,
                Price = honey.Price,
                Amount = honey.Amount,
                ImgPath = honey.ImgPath
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

        public void UpdateAmountOfHoney(string honeyName, int amount)
        {
            var honey = _context.HoneysInTheWarehouse.FirstOrDefault(x => x.Name == honeyName);
            if (honey == null)
                return;

            honey.Amount += amount;
            _context.HoneysInTheWarehouse.Update(honey);
            _context.SaveChanges();
        }

        public ActionResult<IEnumerable<HoneyInTheWarehouse>> GetAllHoneys()
        {
            return _context.HoneysInTheWarehouse;
        }

        public ActionResult<HoneyInTheWarehouseDto> GetHoney(int honeyId)
        {
            var honey = _context.HoneysInTheWarehouse.Where(x => x.Id == honeyId).FirstOrDefault();

            if (honey == null)
                return new NotFoundResult();

            return new HoneyInTheWarehouseDto()
            {
                Name = honey.Name,
                Price = honey.Price,
                Amount = honey.Amount,
                ImgPath = honey.ImgPath
            };
        }
    }
}
