using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidPay.API.Services.DTOs
{
    public class CardDTO
    {
        public long Id { get; set; }
        public string? Number { get; set; }
        public  string? Holder { get; set; }
        public double Balance { get; set; }
    }
}
