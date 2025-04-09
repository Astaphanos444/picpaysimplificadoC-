using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.src.Model.Request;
using app.src.Service.Transferencias;
using Microsoft.AspNetCore.Mvc;

namespace app.src.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransferenciaController : ControllerBase
    {
        private readonly ITransferenciaService _transferenciaService;

        public TransferenciaController(ITransferenciaService transferenciaService)
        {
            _transferenciaService = transferenciaService;
        }

        [HttpPost]
        public async Task<IActionResult> PostTransfer([FromBody]TransferenciaRequest request)
        {
            var result = await _transferenciaService.ExecuteAsync(request);
            if(!result.IsSuccess)
                {return BadRequest(result);};

            return Ok(result);
        }
    }
}