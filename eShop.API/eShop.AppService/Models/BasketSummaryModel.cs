using eShop.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.AppService.Models
{
    public class BasketSummaryModel
    {
        public DateTime CreationDate { get; set; }
        public List<BasketItem> BasketItems { get; set; } = new List<BasketItem>();
        public decimal Total { get; set; }
    }
}
