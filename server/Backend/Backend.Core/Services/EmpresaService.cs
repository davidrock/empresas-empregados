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
    public class EmpresaService : IEmpresaService
    {

        private readonly IUtilsService _utilsService;

        public EmpresaService(IUtilsService utilsService)
        {
            _utilsService = utilsService;
        }

        public int Novo(Empresa model)
        {
            try
            {
                using (var ctx = new DatabaseContext())
                {
                    if (_utilsService.ValidarCnpfcnpj(model.Cnpj))
                    {
                        ctx.Empresas.Add(model);
                        ctx.SaveChanges();

                        return model.Id;
                    }
                    else
                    {
                        throw new Exception("CPF/CNPJ inválido");
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Empresa ObterEmpresa(int id)
        {
            try
            {
                using (var ctx = new DatabaseContext())
                {
                    var empresa = ctx.Empresas.Include(x=> x.Colaboradores).ThenInclude(x=> x.Pessoa).FirstOrDefault(x=> x.Id == id);

                    if (empresa != null)
                        return empresa;
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

        public Empresa Alterar(Empresa model)
        {
            try
            {
                using (var ctx = new DatabaseContext())
                {
                    var edit = ctx.Empresas.Find(model.Id);
                    edit.Nome = model.Nome ?? edit.Nome;
                    edit.RazaoSocial = model.RazaoSocial ?? edit.RazaoSocial;
                    edit.Cnpj = model.Cnpj ?? edit.Cnpj;

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

        public List<Empresa> ListarEmpresas()
        {
            try
            {
                using (var ctx = new DatabaseContext())
                {
                    var empresas = ctx.Empresas.ToList();
                    return empresas;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void RemoverEmpresa(int id)
        {
            try
            {
                using (var ctx = new DatabaseContext())
                {
                    ctx.Empresas.Remove(ObterEmpresa(id));
                    ctx.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public List<Colaborador> ObterColabores(int id)
        {
            throw new NotImplementedException();
        }
    }
}
