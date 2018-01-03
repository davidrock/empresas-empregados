using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Core.Interfaces;
using Backend.Database;
using Backend.Database.Models;

namespace Backend.Core.Services
{
    public class EmpresaService : IEmpresaService
    {
        private readonly DatabaseContext _ctx;
        private readonly IUtilsService _utilsService;

        public EmpresaService(IUtilsService utilsService, DatabaseContext ctx)
        {
            _utilsService = utilsService;
            _ctx = ctx;
        }

        public int Novo(Empresa model)
        {
            try
            {
                if (_utilsService.ValidarCnpfcnpj(model.Cnpj))
                {
                    _ctx.Empresas.Add(model);
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

        public Empresa ObterEmpresa(int id)
        {
            try
            {
                var empresa = _ctx.Empresas.Find(id);

                if (empresa != null)
                    return empresa;
                else
                    throw new Exception("Empresa não encontrada");

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
                var edit = _ctx.Empresas.Find(model.Id);
                edit.Nome = model.Nome;
                edit.RazaoSocial = model.RazaoSocial;
                edit.Cnpj = model.Cnpj;

                _ctx.SaveChanges();

                return edit;
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
                var empresas = _ctx.Empresas.ToList().ToList();
                return empresas;
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
                _ctx.Empresas.Remove(ObterEmpresa(id));
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
