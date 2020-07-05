using HoneyStore.Dto;
using HoneyStore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HoneyStore.Services
{
    public class StatisticsService
    {
        private readonly HoneyStoreContext _context;

        public StatisticsService(HoneyStoreContext context)
        {
            _context = context;
        }

        public ActionResult<NumberOfOrdersDataDto> GetNumberOfOrdersData(int peroid)
        {
            List<int> data = new List<int>();
            var orderedHoneys = _context.OrderedHoneys.ToList();
            var orders = _context.Orders.Where(x => x.Date.Date >= DateTime.Now.AddDays(-peroid).Date).OrderBy(x => x.Date.Date).ToList();
            DateTime date = orders.ElementAt(0).Date.Date;
            int number = 0;

            foreach (var order in orders)
            {
                if (order.Date.Date == date)
                {
                    number += orderedHoneys.Where(x => x.OrderId == order.Id).Sum(x => x.Amount);
                }
                else
                {
                    data.Add(number);
                    number = 0;
                    number += orderedHoneys.Where(x => x.OrderId == order.Id).Sum(x => x.Amount);
                }

                date = order.Date.Date;

            }

            data.Add(number);

            List<string> labels = _context.Orders.Where(x => x.Date.Date >= DateTime.Now.AddDays(-peroid).Date).OrderBy(x => x.Date).Select(x => x.Date.ToShortDateString()).Distinct().ToList();

            return new NumberOfOrdersDataDto()
            {
                Data = data,
                Labels = labels
            };
        }

        public ActionResult<NumberOfOrdersDataDto> GetNumberOfSpecyficOrdersData(int peroid)
        {
            List<string> honeys = _context.HoneysInTheWarehouse.Select(x => x.Name).ToList();
            List<int> data = new List<int>();
            var orders = _context.Orders.Where(x => x.Date.Date >= DateTime.Now.AddDays(-peroid).Date).ToList();

            foreach (var order in orders)
            {
                order.OrderedHoneys = _context.OrderedHoneys.Where(x => x.OrderId == order.Id).ToList();
            }

            int num = 0;

            for (int i = 0; i < honeys.Count; i++)
            {
                foreach (var order in orders)
                {
                    num += order.OrderedHoneys.Where(x => x.Name == honeys.ElementAt(i)).Sum(x => x.Amount);
                }

                data.Add(num);
                num = 0;

            }

            List<string> labels = _context.HoneysInTheWarehouse.Select(x => x.Name).ToList();

            return new NumberOfOrdersDataDto()
            {
                Data = data,
                Labels = labels
            };
        }
    }
}
