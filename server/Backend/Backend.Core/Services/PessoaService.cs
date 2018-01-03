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

        private readonly IUtilsService _utilsService;

        public PessoaService(IUtilsService utilsService)
        {
            _utilsService = utilsService;
        }

        public int Novo(Pessoa model)
        {
            try
            {
                using (var ctx = new DatabaseContext())
                {


                    if (_utilsService.ValidarCnpfcnpj(model.Cpf))
                    {
                        ctx.Pessoas.Add(model);
                        ctx.SaveChanges();

                        return model.Id;
                    }
                    else
                    {
                        throw new Exception("CPF/CNPJ não informado");
                    }
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
                using (var ctx = new DatabaseContext())
                {
                    var pessoa = ctx.Pessoas.Find(id);

                    if (pessoa != null)
                        return pessoa;
                    else
                        throw new Exception("Pessoa não encontrada");

                }
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
                using (var ctx = new DatabaseContext())
                {
                    var edit = ctx.Pessoas.Find(model.Id);
                    edit.Cpf = model.Cpf ?? edit.Cpf;
                    edit.Nome = model.Nome ?? edit.Nome;
                    edit.DtNascimento = model.DtNascimento == DateTime.MinValue ? edit.DtNascimento : model.DtNascimento;

                    ctx.SaveChanges();

                    return edit;
                }
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
                using (var ctx = new DatabaseContext())
                {
                    var pessoas = ctx.Pessoas.ToList().ToList();
                    return pessoas;
                }
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
                using (var ctx = new DatabaseContext())
                {
                    ctx.Pessoas.Remove(ObterPessoa(id));
                    ctx.SaveChanges();
                }
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
