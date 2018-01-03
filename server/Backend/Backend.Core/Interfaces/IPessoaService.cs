using System;
using System.Collections.Generic;
using System.Text;
using Backend.Database.Models;

namespace Backend.Core.Interfaces
{
    public interface IPessoaService
    {
        int Novo(Pessoa model);
        Pessoa ObterPessoa(int id);
        Pessoa Alterar(Pessoa model);
        List<Pessoa> ListarPessoas();
        void RemoverPessoa(int id);
        List<Colaborador> ObterEmpregos();
    }
}
