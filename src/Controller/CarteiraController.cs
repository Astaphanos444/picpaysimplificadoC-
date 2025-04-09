using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.src.Model.Request;
using app.src.Service.Carteiras;
using Microsoft.AspNetCore.Mvc;

namespace app.src.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarteiraController : ControllerBase
    {
        private readonly ICarteiraService _carteiraService;
        public CarteiraController(ICarteiraService carteiraService)
        {
            _carteiraService = carteiraService;
        }

        [HttpPost]
        public async Task<IActionResult> PostCarteira([FromBody]CarteiraRequest carteira)
        {
            var result = await _carteiraService.ExecuteAsync(carteira);

            if(!result.IsSuccess)
            {return BadRequest(result);};

            return Created();
        }
    }
}