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

        //GET: api/Endereco/ListarEnderecos
        [HttpGet]
        [Route("ListarEnderecos")]
        public IActionResult listar()
        {
            return Ok(_enderecoDAO.Listar());
        }

        //GET: api/Endereco/ListarCepEspecifico
        [HttpGet]
        [Route("ListarEnderecos/{cep}")]
        public IActionResult ListarEnderecos(string cep)
        {
            return Ok(_enderecoDAO.ListarEnderecos(cep));
        }

        //POST: api/Endereco/CadastrarEndereco
        [HttpPost]
        [Route("CadastrarEndereco")]
        public IActionResult Cadastrar(Endereco endereco)
        {
            _enderecoDAO.Cadastrar(endereco);
            return Created("", endereco);
        }

        //DELETE: api/Endereco/DeletarEndereco/id
        [HttpDelete("{CepId}")]
        [Route("DeletarEndereco/{CepId}")]
        public IActionResult Remover(int CepId)
        {
            _enderecoDAO.Remover(CepId);
            return Ok();
        }


        //PUT: api/Endereco/AlterarEndereco/id
        [HttpPut("{CepId}")]
        [Route("AlterarEndereco/{id}")]
        public IActionResult Atualizar(int id, Endereco endereco)
        {
            _enderecoDAO.Atualizar(id, endereco);
            return Ok();
        }
    }
}