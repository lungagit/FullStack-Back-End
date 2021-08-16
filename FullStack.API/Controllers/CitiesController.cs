using FullStack.API.Services;
using FullStack.Data.Entities;
using FullStack.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStack.API.Controllers
{
    
    [ApiController]
    [Route("api/provinces/{provinceId}/cities")]
    public class CitiesController : ControllerBase
    {
        private readonly ICityService _cityService;
        public CitiesController(ICityService cityService)
        {
            _cityService = cityService;
        }
        [Authorize]
        [HttpGet]
        public ActionResult<IEnumerable> GetCities(int provinceId)
        {
            var citiesForProvince = _cityService.GetCities(provinceId);
            return Ok(citiesForProvince);
        }
    }


}
