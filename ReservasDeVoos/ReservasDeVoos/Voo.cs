using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservasDeVoos
{
    class Voo
    {
        private int vagas = (int)Constantes.valoresPadrao.vagasPorVoo;
        private int codVoo;
        private Assento[] assentoA = new AssentoA[(int)Constantes.valoresPadrao.assentosA];
        private Assento[] assentoB = new AssentoB[(int)Constantes.valoresPadrao.assentosB];
        private Assento[] assentoC = new AssentoC[(int)Constantes.valoresPadrao.assentosC];

        public int Vagas { get => vagas; set => vagas = value; }
        public int CodVoo { get => codVoo; set => codVoo = value; }
        public Assento[] AssentoA { get => assentoA; set => assentoA = value; }
        public Assento[] AssentoB { get => assentoB; set => assentoB = value; }
        public Assento[] AssentoC { get => assentoC; set => assentoC = value; }

        public Voo(int codVoo)
        {
            this.codVoo = codVoo;
        }
        public Voo() { }
    }
}
