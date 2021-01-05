using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FundosInvestimentos.Data;
using FundosInvestimentos.Models;
using Microsoft.AspNetCore.Mvc;

namespace FundosInvestimentos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InstituicaoController : ControllerBase
    {
        private readonly IRepository _repository;
        public InstituicaoController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult Post(Instituicao instituicao)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            try
            {

                return Ok(_repository.Post(instituicao));
            }
            catch (System.Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(Instituicao instituicao)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            try
            {

                return Ok(_repository.Delete(instituicao));
            }
            catch (System.Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(Instituicao instituicao)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            try
            {

                return Ok(_repository.Update(instituicao));
            }
            catch (System.Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest();
            try
            {

                return Ok(_repository.GetAllInstituicao());
            }
            catch (System.Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}", Name = "GetWithId")]
        public IActionResult GetById(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            try
            {

                return Ok(_repository.GetInstituicaoById(id));
            }
            catch (System.Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

    }
}