using System.Threading.Tasks;
using FundosInvestimentos.Interfaces.TipoInstituicaoInterface;
using Microsoft.AspNetCore.Mvc;

namespace FundosInvestimentos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipoInstituicaoController : ControllerBase
    {
        private readonly TipoInstituicaoInterface _tipoInstituicaoService;
        public TipoInstituicaoController(TipoInstituicaoInterface tipoInstituicaoService)
        {
            _tipoInstituicaoService = tipoInstituicaoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTipos()
        {
            return Ok(await _tipoInstituicaoService.GetAllTiposInstituicao());
        }
    }
}