using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FundosInvestimentos.Dtos;
using FundosInvestimentos.Dtos.Instituicao;
using FundosInvestimentos.Interfaces.InstituicaoInterface;
using Microsoft.AspNetCore.Mvc;

namespace FundosInvestimentos.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class InstituicaoController : ControllerBase
    {
        private readonly InstituicaoServiceInterface _service;
        private readonly IMapper _mapper;
        public InstituicaoController(InstituicaoServiceInterface service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest();
            try
            {
                var instituicoesCadastradas = await _service.GetAllInstituicao();
                var instituicaoCadastradasRetorno = _mapper.Map<IEnumerable<InstituicaoDto>>(instituicoesCadastradas);

                return Ok(instituicaoCadastradasRetorno);
            }
            catch (System.Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}", Name = "GetWithId")]
        public async Task<IActionResult> GetById(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            try
            {

                return Ok(await _service.GetInstituicaoById(id));
            }
            catch (System.Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(InstituicaoDtoCreate instituicao)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            try
            {
                return Ok(await _service.PostInstituicao(instituicao));
            }
            catch (System.Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

    }
}