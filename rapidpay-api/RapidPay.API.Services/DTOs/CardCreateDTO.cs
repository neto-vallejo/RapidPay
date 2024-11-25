using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidPay.API.Services.DTOs
{
    public class CardCreateDTO
    {

        [Required]
        public string? Number { get; set; }
        [Required]
        public  string? Holder { get; set; }
        public double InitialBalance { get; set; }
    }
}
