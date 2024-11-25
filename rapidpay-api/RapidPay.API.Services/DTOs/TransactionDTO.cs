using RapidPay.API.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidPay.API.Services.DTOs
{
    public class TransactionDTO
    {
        public long CardNumber { get; set; }
        public double Amount { get; set; }
        public double Fee { get; set; }
        public double TotalAmount { get; set; }
        public string? Description { get; set; }
    }
}
