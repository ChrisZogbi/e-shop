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
        public string CreationDate { get; set; }
        public List<ItemSummaryModel> BasketItems { get; set; } = new List<ItemSummaryModel>();
        public decimal Total { get; set; }
    }
}
