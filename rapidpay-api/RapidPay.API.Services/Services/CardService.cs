using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using RapidPay.API.Data.Entities;
using RapidPay.API.Services.DataServices;
using RapidPay.API.Services.DTOs;
using RapidPay.Common;
using System.Net;

namespace RapidPay.API.Services.Services
{
    public class CardService(IDataService dataService, IMapper mapper) : ICardService
    {
        private readonly IDataService _dataService = dataService;
        private readonly IMapper _mapper = mapper;

        public async Task<CardDTO> CreateNewCard(CardCreateDTO cardDto, string userId)
        {
            //TODO: validate DTO and return BadRequest

            var card = _mapper.Map<Card>(cardDto);
            card.UserId = userId;
            try
            {
                var createdNewCard = await _dataService.CreateNewCard(card);

                return _mapper.Map<CardDTO>(createdNewCard);
            }
            catch (Exception ex)
            {
                //log exception
                // return meaningful error message
                throw new ApiException(HttpStatusCode.BadRequest,"Error creating new card");
            }
        }

        public async Task<CardDTO> GetCardBalance(long cardID, string userId)
        {

            try
            {
                var card = await _dataService.Cards.Where(c => c.Id == cardID && c.UserId == userId).FirstOrDefaultAsync();

                if(card == null)
                {
                    throw new ApiException(HttpStatusCode.NotFound, "Card not found");
                }

                return _mapper.Map<CardDTO>(card);
            }
            catch (Exception ex)
            {
                //log exception
                // return meaningful error message
                throw new ApiException(HttpStatusCode.BadRequest, "Error getting card");
            }
        }

        public async Task<CardDTO> GetCardBalance(string cardNumber, string userId)
        {
            //validate DTO and return BadRequest

            try
            {
                var card = await _dataService.Cards.Where(c => c.Number == cardNumber && c.UserId == userId).FirstOrDefaultAsync();

                if (card == null)
                {
                    throw new ApiException(HttpStatusCode.NotFound, "Card not found");
                }

                return _mapper.Map<CardDTO>(card);
            }
            catch (Exception ex)
            {
                //log exception
                // return meaningful error message
                throw new ApiException(HttpStatusCode.BadRequest, "Error getting card");
            }
        }

    }
}
