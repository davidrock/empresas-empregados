using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Core.Interfaces;
using Backend.Database;
using Backend.Database.Models;

namespace Backend.Core.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly DatabaseContext _ctx;
        private readonly IUtilsService _utilsService;

        public PessoaService(DatabaseContext context, IUtilsService utilsService)
        {
            _ctx = context;
            _utilsService = utilsService;
        }

        public int Novo(Pessoa model)
        {
            try
            {
                if (_utilsService.ValidarCnpfcnpj(model.Cpf))
                {
                    _ctx.Pessoas.Add(model);
                    _ctx.SaveChanges();

                    return model.Id;
                }
                else
                {
                    throw new Exception("CPF/CNPJ não informado");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Pessoa ObterPessoa(int id)
        {
            try
            {
                var pessoa = _ctx.Pessoas.Find(id);

                if (pessoa != null)
                    return pessoa;
                else
                    throw new Exception("Pessoa não encontrada");

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Pessoa Alterar(Pessoa model)
        {
            try
            {
                var edit = _ctx.Pessoas.Find(model.Id);
                edit.Cpf = model.Cpf;
                edit.Nome = model.Nome;
                edit.DtNascimento = model.DtNascimento;

                _ctx.SaveChanges();

                return edit;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public List<Pessoa> ListarPessoas()
        {
            try
            {
                var pessoas = _ctx.Pessoas.ToList().ToList();
                return pessoas;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void RemoverPessoa(int id)
        {
            try
            {
                _ctx.Pessoas.Remove(ObterPessoa(id));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public List<Colaborador> ObterEmpregos()
        {
            throw new NotImplementedException();
        }
    }
}
