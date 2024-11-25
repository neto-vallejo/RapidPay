using RapidPay.API.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidPay.API.Services.Services
{
    public interface IPaymentService
    {
        Task<TransactionDTO> AddPayment(PaymentDTO paymentDto, string userId);
    }
}
