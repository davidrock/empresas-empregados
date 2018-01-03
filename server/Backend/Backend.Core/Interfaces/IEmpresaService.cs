using System;
using System.Collections.Generic;
using System.Text;
using Backend.Database.Models;

namespace Backend.Core.Interfaces
{
    public interface IEmpresaService
    {
        int Novo(Empresa model);
        Empresa ObterEmpresa(int id);
        Empresa Alterar(Empresa model);
        List<Empresa> ListarEmpresas();
        void RemoverEmpresa(int id);
        List<Colaborador> ObterColabores(int id);
    }
}
