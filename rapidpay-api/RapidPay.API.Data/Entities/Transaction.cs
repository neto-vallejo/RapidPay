using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidPay.API.Data.Entities
{
    public class Transaction
    {
        public long Id { get; set; }
        public long CardId { get; set; }
        public required Card Card { get; set; }
        public double Amount { get; set; }
        public double Fee { get; set; }
        public double TotalAmount { get; set; }
        public string? Description { get; set; }
    }
}
