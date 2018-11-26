using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservasDeVoos
{
    abstract class Assento
    {
        private bool isReservado;
        private Passageiro passageiro;
        public bool IsReservado { get => isReservado; set => isReservado = value; }
        public Passageiro Passageiro { get => passageiro; set => passageiro = value; }
               
        public Assento()
        {
            isReservado = false;
            Passageiro = null;
        }

        public bool isAssentoReservado()
        {
            return isReservado;
        }

        public void insertPassageiro(Passageiro usuario)
        {
            if (isReservado == true)
            {
                throw new Exception("Assento já reservado.");
            }
            this.passageiro = usuario;
            isReservado = true;
        }

        

    }
}
