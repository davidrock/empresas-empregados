using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Database.Models
{
    public partial class Pessoa
    {

        public Pessoa()
        {
            Colaboradores = new HashSet<Colaborador>();
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DtNascimento { get; set; }
        public DateTime DtCadastro { get; set; }

        public ICollection<Colaborador> Colaboradores { get; set; }
    }
}
