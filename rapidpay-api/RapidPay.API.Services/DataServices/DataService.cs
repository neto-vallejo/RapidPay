using RapidPay.API.Data.Database;
using RapidPay.API.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RapidPay.API.Services.DataServices
{
    //TODO: maybe move this to a different project for data access only
    public class DataService : IDataService
    {
        private readonly DataContext _db;
        public DataService(DataContext db)
        {
            _db = db;
        }

        public IQueryable<Card> Cards => _db.Cards;
        public IQueryable<Transaction> Transactions => _db.Transactions;

        public async Task<Card> CreateNewCard(Card card)
        {
            _db.Cards.Add(card);
            await _db.SaveChangesAsync();

            return card;
        }

        public async Task<Card> UpdateCard(Card card)
        {
            _db.Cards.Update(card);
            await _db.SaveChangesAsync();

            return card;
        }

        public async Task<Transaction> CreateNewTransaction(Transaction transaction)
        {
            _db.Transactions.Add(transaction);
            await _db.SaveChangesAsync();

            return transaction;
        }
    }
}
