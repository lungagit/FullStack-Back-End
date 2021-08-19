
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FullStack.API.Helpers;
using FullStack.API.Services;
using FullStack.Data.Entities;
using FullStack.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FullStack.API.Controllers
{
    [Route("api/users/{userId}/adverts")]
    [ApiController]
    public class AdvertsController : ControllerBase
    {
        private readonly IAdvertService _advertService;
        public AdvertsController(IAdvertService advertService)
        {
            _advertService = advertService;
        }

        [HttpGet]
        public IActionResult GetAll(int userId)
        {
            var adverts = _advertService.GetAll(userId);
            return Ok(adverts);
        }

        [HttpGet("{advertId}")]
        public IActionResult GetAdvert(int advertId)
        {
            var advert = _advertService.GetById(advertId);
            if (advert == null) return NotFound();

            return Ok(advert);
            
        }
        [Authorize]
        [HttpPost]
        public IActionResult CreateAdvert(int userId, AdvertModel advert)
        {
            try
            {
                var advertEntity =  _advertService.CreateAdvert(userId, Map(advert));
                //var advertToReturn = 
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
            
        }
        [Authorize]
        [HttpPut("{advertId}")]
        public IActionResult UpdateAdvert(int userId, int advertId, [FromBody]AdvertModel advert)
        {
            var ad = Map(advert);
            ad.Id = advertId;

            try
            {
                _advertService.UpdateAdvert(userId, Map(advert));
                return Ok();
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        //Helper methods
        private Advert Map(AdvertModel advert)
        {
            return new Advert
            {
                Id = advert.Id,
                Headline = advert.Headline,
                ProvinceId = advert.ProvinceId,
                CityId = advert.CityId,
                Status = advert.Status,
                AdvertDetails = advert.AdvertDetails,
                Price = advert.Price,
                Deleted = advert.Deleted,
                Hidden = advert.Hidden,
                UserId = advert.UserId,
            };
        }

    }
}
