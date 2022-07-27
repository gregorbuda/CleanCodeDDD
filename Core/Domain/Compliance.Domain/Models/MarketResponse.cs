using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Domain.Models
{
    public class MarketResponse
    {
        public int Id { get; set; }
        public string MarketName { get; set; }
        public string MarketDescription { get; set; }
        public string MarketCurrency { get; set; }
        public string CurrencySymbol { get; set; }
    }
}
