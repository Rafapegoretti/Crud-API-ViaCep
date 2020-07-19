using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aula2Asp.net.DAL;
using Aula2Asp.net.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aula2Asp.net.Controllers
{
    [Route("api/Endereco")]
    [ApiController]
    public class EnderecoAPIController : ControllerBase
    {
        private readonly EnderecoDAO _enderecoDAO;
        public EnderecoAPIController(EnderecoDAO enderecoDAO)
        {
            _enderecoDAO = enderecoDAO;
        }

        //GET: api/Endereco/Listar
        [HttpGet]
        [Route("Listar")]
        public IActionResult listar()
        {
            return Ok(_enderecoDAO.Listar());
        }

        //POST: api/Endereco/Cadastrar
        [HttpPost]
        [Route("Cadastrar")]
        public IActionResult Cadastrar(Endereco endereco)
        {
            _enderecoDAO.Cadastrar(endereco);
            return Created("", endereco);
        }

        //POST: api/Endereco/Remover
        [HttpDelete]
        [Route("Remover")]
        public IActionResult Remover(int CepId)
        {
           _enderecoDAO.Remover(CepId);
            return Ok();

        }

    }
}