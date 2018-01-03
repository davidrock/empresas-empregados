using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Core.Interfaces;
using Backend.Database;
using Backend.Database.Models;

namespace Backend.Core.Services
{
    public class ColaboradorService : IColaboradorService
    {
        private readonly DatabaseContext _ctx;

        public ColaboradorService(DatabaseContext ctx)
        {
            _ctx = ctx;
        }

        public void Novo(Colaborador model)
        {
            try
            {
                var novo = new Colaborador();
                novo.Pessoa = _ctx.Pessoas.Find(model.PessoaId);
                novo.Empresa = _ctx.Empresas.Find(model.EmpresaId);
                novo.Cargo = model.Cargo;
                novo.DtCadastro = DateTime.Now;
                novo.Salario = model.Salario;
                novo.Status = (int)Enums.Status.Ativo;

                _ctx.Colaboradores.Add(novo);
                _ctx.SaveChanges();
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
                var edit = _ctx.Colaboradores.FirstOrDefault(x => x.PessoaId == model.PessoaId && x.EmpresaId == model.EmpresaId);
                edit.Salario = model.Salario;
                edit.Cargo = model.Cargo;

                _ctx.SaveChanges();

                return edit;
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
                var colaboradores = _ctx.Colaboradores.ToList();
                return colaboradores;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void DemitirColaborador(int id)
        {
            try
            {
                var colaborador = _ctx.Colaboradores.Find(id);
                colaborador.Status = (int) Enums.Status.Inativo;
                colaborador.DtDemissao = DateTime.Now;
                _ctx.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void RemoverColaborador(int id)
        {
            try
            {

                var colaborador = _ctx.Colaboradores.Find(id);

                if (colaborador != null)
                    _ctx.Colaboradores.Remove(colaborador);

                else
                    throw new Exception("Colaborador não encontrado!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }

}
