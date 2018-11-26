using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservasDeVoos
{
    class Passageiro
    {
        private string cpf,nome;
        public string Cpf { get => cpf; set => cpf = value; }
        public string Nome { get => cpf; set => cpf = value; }

        public Passageiro(string cpf, string nome)
        {
            this.nome = nome;
            this.cpf = cpf;
        }

    }
}
