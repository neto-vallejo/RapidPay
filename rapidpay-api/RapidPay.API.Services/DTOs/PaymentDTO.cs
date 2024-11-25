using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidPay.API.Services.DTOs
{
    public class PaymentDTO
    {
        [Required]
        [MaxLength(15)]
        public string? CardNumber { get; set; }

        [Required]
        public double Amount { get; set; }
        public string? Description { get; set; }
    }
}
