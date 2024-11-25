using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidPay.API.Data.Entities
{
    //TODO: Card number should not be stored directly in database for PCI compliance
    public class Card
    {
        public long Id { get; set; }
        public required string UserId { get; set; }
        public required IdentityUser User { get; set; }
        public required string Number { get; set; }
        public required string Holder { get; set; }
        public double Balance { get; set; }
    }
}
