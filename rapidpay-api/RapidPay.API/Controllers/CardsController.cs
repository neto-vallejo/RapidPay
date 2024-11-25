using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RapidPay.API.Data.Entities;
using RapidPay.API.Services.DTOs;
using RapidPay.API.Services.Services;
using System.Runtime.CompilerServices;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RapidPay.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController(ICardService cardService) : ControllerBase
    {
        readonly ICardService _cardService = cardService;

        [HttpPost]
        public async Task<ActionResult<CardDTO>> CreateNewCard([FromBody] CardCreateDTO card)
        {
            string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var result = await _cardService.CreateNewCard(card,userId);

            return Ok(result);
        }

        //TODO: use card id instead of card number
        //[HttpGet("{id}")]
        //public async Task<CardDTO> GetCardBalance(long id)
        //{
        //    var result = await _cardService.GetCardBalance(id);

        //    return result;
        //}

        [HttpGet("{number}")]
        public async Task<ActionResult<CardDTO>> GetCardBalance(string number)
        {
            string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var result = await _cardService.GetCardBalance(number,userId);

            return Ok(result);
        }

    }
}
