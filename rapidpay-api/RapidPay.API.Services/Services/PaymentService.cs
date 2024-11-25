using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RapidPay.API.Data.Entities;
using RapidPay.API.Services.DataServices;
using RapidPay.API.Services.DTOs;
using RapidPay.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RapidPay.API.Services.Services
{
    public class PaymentService(IDataService dataService, IMapper mapper) : IPaymentService
    {
        private readonly IDataService _dataService = dataService;
        private readonly IMapper _mapper = mapper;


        public async Task<TransactionDTO> AddPayment(PaymentDTO paymentDto, string userId)
        {
            //TODO: validate DTO 
            //TODO: should use cardId instead of card number and validate card exists 

            var transaction = _mapper.Map<Transaction>(paymentDto);

            try
            {
                var card = await _dataService.Cards.Where(c => c.Number == paymentDto.CardNumber && c.UserId == userId).FirstOrDefaultAsync();
                //get fee
                double fee = FeeServiceSingleton.Instance.GetCurrentFee();
                transaction.CardId = card.Id;
                transaction.Fee = fee;
                transaction.TotalAmount = transaction.Amount + fee;

                card.Balance = card.Balance - transaction.TotalAmount;

                var newTransaction = await _dataService.CreateNewTransaction(transaction);

                await _dataService.UpdateCard(card);

                return _mapper.Map<TransactionDTO>(newTransaction);
            }
            catch (Exception ex)
            {
                //log error exception 
                // return meaningful exception to users
                throw new ApiException(HttpStatusCode.BadRequest, "Error adding payment");
            }
        }
    }
}
