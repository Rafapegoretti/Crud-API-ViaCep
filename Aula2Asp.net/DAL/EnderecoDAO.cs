using Aula2Asp.net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aula2Asp.net.DAL
{
    public class EnderecoDAO
    {
        private readonly Context _context;
        public EnderecoDAO(Context context)
        {
            _context = context;
        }
        public void Cadastrar(Endereco endereco)
        {
            _context.Enderecos.Add(endereco);
            _context.SaveChanges();
        }

        public List<Endereco> Listar()
        {
            return _context.Enderecos.ToList();
        }

        public void Remover(int CepId)
        {
            Endereco endereco = _context.Enderecos.Find(CepId);
            _context.Remove(endereco);
            _context.SaveChanges();
        }

        public void Atualizar(Endereco endereco)
        {
            var enderecoAtt = _context.Enderecos.Where(e => e.CepId == endereco.CepId).FirstOrDefault();

            enderecoAtt.Cep = endereco.Cep;
            enderecoAtt.Logradouro = endereco.Logradouro;
            enderecoAtt.Complemento = endereco.Complemento;
            enderecoAtt.Bairro = endereco.Bairro;
            enderecoAtt.Localidade = endereco.Localidade;
            enderecoAtt.Uf = endereco.Uf;

            _context.SaveChanges();

        }
    }
}
