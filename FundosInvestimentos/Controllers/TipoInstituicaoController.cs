using FundosInvestimentos.Data;
using Microsoft.AspNetCore.Mvc;

namespace FundosInvestimentos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipoInstituicaoController : ControllerBase
    {
        private readonly IRepository _repository;
        public TipoInstituicaoController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetTodosTiposInstituicao()
        {
            return Ok(_repository.GetAllTipoInstituicao());
        }
    }
}