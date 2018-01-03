using System;
using System.Collections.Generic;
using System.Text;
using Backend.Database.Models;

namespace Backend.Core.Interfaces
{
    public interface IColaboradorService
    {
        void Novo(Colaborador model);
        Colaborador ObterColaborador(int id);
        Colaborador Alterar(Colaborador model);
        List<Colaborador> ListarColaboradores();
        void DemitirColaborador(Colaborador model);
        void RemoverColaborador(Colaborador model);
    }
}
