using RapidPay.API.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidPay.API.Services.DataServices
{
    public interface IDataService
    {
        public IQueryable<Card> Cards { get; }
        public IQueryable<Transaction> Transactions { get; }
        Task<Card> CreateNewCard(Card card);
        Task<Card> UpdateCard(Card card);
        Task<Transaction> CreateNewTransaction(Transaction transaction);
    }
}
