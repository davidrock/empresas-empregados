using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Core.Interfaces;
using Backend.Database;
using Backend.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Core.Services
{
    public class ColaboradorService : IColaboradorService
    {


        public void Novo(Colaborador model)
        {
            try
            {
                using (var ctx = new DatabaseContext())
                {
                    var novo = new Colaborador();
                    novo.Pessoa = ctx.Pessoas.Find(model.PessoaId);
                    novo.Empresa = ctx.Empresas.Find(model.EmpresaId);
                    novo.Cargo = model.Cargo;
                    novo.DtCadastro = DateTime.Now;
                    novo.Salario = model.Salario;
                    novo.Status = (int)Enums.Status.Ativo;

                    ctx.Colaboradores.Add(novo);
                    ctx.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Colaborador ObterColaborador(int id)
        {
            try
            {
                using (var ctx = new DatabaseContext())
                {
                    var colaborador = ctx.Colaboradores.Find(id);

                    if (colaborador != null)
                        return colaborador;
                    else
                        throw new Exception("Empresa não encontrada");

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Colaborador Alterar(Colaborador model)
        {
            try
            {
                using (var ctx = new DatabaseContext())
                {
                    var edit = ctx.Colaboradores.FirstOrDefault(x => x.PessoaId == model.PessoaId && x.EmpresaId == model.EmpresaId);
                    edit.Salario = model.Salario == Decimal.MinValue ? edit.Salario : model.Salario;
                    edit.Cargo = model.Cargo ?? edit.Cargo;

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

        public List<Colaborador> ListarColaboradores()
        {
            try
            {
                using (var ctx = new DatabaseContext())
                {
                    var colaboradores = ctx.Colaboradores.Include(x => x.Pessoa).Include(x => x.Empresa).ToList();
                    return colaboradores;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void DemitirColaborador(Colaborador model)
        {
            try
            {
                using (var ctx = new DatabaseContext())
                {
                    var colaborador = ctx.Colaboradores.First(x =>
                    x.PessoaId == model.PessoaId && x.EmpresaId == model.EmpresaId &&
                    x.Status == (int)Enums.Status.Ativo);

                    if (colaborador == null)
                        throw new Exception("Colaborador não encontrado");

                    colaborador.Status = (int)Enums.Status.Inativo;
                    colaborador.DtDemissao = DateTime.Now;
                    ctx.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void RemoverColaborador(Colaborador model)
        {
            try
            {
                using (var ctx = new DatabaseContext())
                {
                    var colaborador = ctx.Colaboradores.First(x =>
                    x.PessoaId == model.PessoaId && x.EmpresaId == model.EmpresaId);

                    if (colaborador != null)
                        ctx.Colaboradores.Remove(colaborador);

                    else
                        throw new Exception("Colaborador não encontrado!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }

}
