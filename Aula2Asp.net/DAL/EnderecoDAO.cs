using Aula2Asp.net.Models;
using Microsoft.EntityFrameworkCore;
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

        public List<Endereco> ListarEnderecos(string cep)
        {
            return _context.Enderecos.Where(e => e.Cep == cep).ToList();
        }

        public void Remover(int CepId)
        {
            Endereco endereco = _context.Enderecos.Find(CepId);
            _context.Remove(endereco);
            _context.SaveChanges();
        }

        public void Atualizar(int id,Endereco endereco)
        {
            var enderecoAtt = _context.Enderecos.Where(e => e.CepId == id).FirstOrDefault();

            endereco.Cep = enderecoAtt.Cep;
            endereco.Complemento = enderecoAtt.Complemento;
            endereco.Bairro = enderecoAtt.Bairro;
            endereco.Logradouro = enderecoAtt.Logradouro;
            endereco.Uf = enderecoAtt.Uf;

            _context.Entry(endereco).State = EntityState.Modified;
            _context.SaveChangesAsync();

        }
    }
}
