using RapidPay.API.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidPay.API.Services.Services
{
    public interface ICardService
    {
        Task<CardDTO> CreateNewCard(CardCreateDTO cardDto, string userId);
        Task<CardDTO> GetCardBalance(long cardID, string userId);
        Task<CardDTO> GetCardBalance(string cardID, string userId);
    }
}
