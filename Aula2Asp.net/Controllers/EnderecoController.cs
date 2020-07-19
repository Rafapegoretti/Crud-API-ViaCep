using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Aula2Asp.net.DAL;
using Aula2Asp.net.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Aula2Asp.net.Controllers
{
    public class EnderecoController : Controller
    {
        private readonly EnderecoDAO _enderecoDAO;
        public EnderecoController(EnderecoDAO enderecoDAO)
        {
            _enderecoDAO = enderecoDAO;
        }
        public IActionResult Index()
        {

            if (TempData["Dados"] != null)
            {
                string resultado = TempData["Dados"].ToString();
                Endereco endereco = JsonConvert.DeserializeObject<Endereco>(resultado);

                _enderecoDAO.Cadastrar(endereco);

                return View(_enderecoDAO.Listar());

            }
            return View(_enderecoDAO.Listar());
        }

        [HttpPost]
        public IActionResult PesquisarCEP(string txtCep)
        {
            string url = $@"http://viacep.com.br/ws/{txtCep}/json/";
            WebClient cliente = new WebClient();
            TempData["Dados"] = cliente.DownloadString(url);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Remover(int id)
        {
            _enderecoDAO.Remover(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Atualizar(Endereco endereco)
        {
            _enderecoDAO.Atualizar(endereco);
            return RedirectToAction("Index");
        }


    }
}