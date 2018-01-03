using System;
using System.Collections.Generic;
using System.Text;
using Backend.Database.Models;

namespace Backend.Core.Interfaces
{
    public interface IColaboradorService
    {
        void Novo(Colaborador model);
        Colaborador Alterar(Colaborador model);
        List<Colaborador> ListarColaboradores();
        void DemitirColaborador(int id);
        void RemoverColaborador(int id);
    }
}
