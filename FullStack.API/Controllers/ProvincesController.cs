using FullStack.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStack.API.Controllers
{
    [Route("api/provinces")]
    [ApiController]
    public class ProvincesController: ControllerBase
    {
        private readonly IProvinceService _provinceService;
        public ProvincesController(IProvinceService provinceService)
        {
            _provinceService = provinceService;
        }
        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            var provinces = _provinceService.GetAll();
            return Ok(provinces);
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetProvince(int id)
        {
            var province = _provinceService.GetById(id);
            if (province == null) return NotFound();

            return Ok(province);
        }
    }
}
