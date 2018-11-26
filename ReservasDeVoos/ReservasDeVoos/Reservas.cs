using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservasDeVoos
{
    class Reservas
    {
        private Voo[] voos = new Voo[(int)Constantes.valoresPadrao.numVoos];
        public Voo[] Voos { get => voos; set => voos = value; }
        
        public Reservas()
        {
            InicializarDados();
        }

        private void InicializarDados()
        {
            Console.WriteLine("Carga de dados inicial Aleatório sendo carregado...");
            //instanciar voos e assentos
            for (int i = 0; i < voos.Length; i++)
            {
                //preenche números dos voos
                voos[i] = new Voo(validaCodVoo(i));
                //instancia os assentos do voo
                instanciaAssentos(voos[i].AssentoA, (int)Constantes.valoresPadrao.assentosAcod);
                instanciaAssentos(voos[i].AssentoB, (int)Constantes.valoresPadrao.assentosBcod);
                instanciaAssentos(voos[i].AssentoC, (int)Constantes.valoresPadrao.assentosCcod);
            }
            //preencher voos aleatoriamente
            preencheVoosRandom();
            Console.WriteLine("Carga de dados iniciais concluída.");
        }
        private int validaCodVoo(int i)
        {
            if (i < (int)Constantes.valoresPadrao.numVoos-20)
                i = 1000 + i + 1;
            else if (i < (int)Constantes.valoresPadrao.numVoos-10)
                i = 2000 + i + 1 -10;
            else
                i = 3000 + i + 1 - 20;
            return i;
        }
        private void instanciaAssentos(Assento[] v, int assentoCod)
        {
            switch (assentoCod)
            {
                case (int)Constantes.valoresPadrao.assentosAcod:
                    for (int i = 0; i < v.Length; i++)
                    {
                        v[i] = new AssentoA();
                    }
                    break;
                case (int)Constantes.valoresPadrao.assentosBcod:
                    for (int i = 0; i < v.Length; i++)
                    {
                        v[i] = new AssentoB();
                    }
                    break;
                case (int)Constantes.valoresPadrao.assentosCcod:
                    for (int i = 0; i < v.Length; i++)
                    {
                        v[i] = new AssentoC();
                    }
                    break;
                default:
                    break;
            }
            
        }
        private void preencheVoosRandom()
        {
            Random r = new Random();
            int totalVoos = (int)Constantes.valoresPadrao.numVoos * (int)Constantes.valoresPadrao.vagasPorVoo;
            int count = 0;

            while (count < totalVoos*0.7)
            {
                var v = voos[r.Next(0, (int)Constantes.valoresPadrao.numVoos - 1)];
                int x = r.Next(0, (int)Constantes.valoresPadrao.vagasPorVoo - 1);
                Assento a;
                if (x < 5)
                {
                    a = v.AssentoA[r.Next(0, (int)Constantes.valoresPadrao.assentosA - 1)];
                }
                else if (x < 10)
                {
                    a = v.AssentoB[r.Next(0, (int)Constantes.valoresPadrao.assentosB - 1)];
                }
                else
                {
                    a = v.AssentoC[r.Next(0, (int)Constantes.valoresPadrao.assentosC - 1)];
                }
                try
                {
                    string cpf = r.Next(0, 999999999).ToString("D9");
                    string nome = "";

                    a.insertPassageiro(new Passageiro(cpf,nome));
                    v.Vagas--;
                }
                catch (Exception ex)
                {
                    //Caso já haja um passageiro no assento, diminui o count para poder preencher os lugares solicitados aleatoriamente
                    //Console.WriteLine("Voo: {0} Assento: {1} - {2}", v.CodVoo, a.ToString(), ex.Message);
                    count--;
                }
                count++;
            }
        }
        public int vagasRemanescentesTotal()
        {
            int vagas = 0;
            foreach (var v in voos)
            {
                vagas += v.Vagas;
            }
            return vagas;
        }
        public void imprimirReservas(int numVoo)
        {
            var v = GetVoo(numVoo);
            Console.WriteLine("Voo código: {0}",numVoo);
            Console.WriteLine("Reservas: {0}", (int)Constantes.valoresPadrao.vagasPorVoo - v.Vagas);
            imprimeAssentos(v.AssentoA);
            imprimeAssentos(v.AssentoB);
            imprimeAssentos(v.AssentoC);
        }
        private Voo GetVoo(int numVoo)
        {
            //var v = voos.ToList();
            var voo = voos.Where(y => y.CodVoo == numVoo).
                Select(x => new Voo()
                {
                    Vagas = x.Vagas,
                    CodVoo = x.CodVoo,
                    AssentoA = x.AssentoA,
                    AssentoB = x.AssentoB,
                    AssentoC = x.AssentoC
                }).ToList();
            return voo.FirstOrDefault();
        }
        private void imprimeAssentos(Assento[] assentos)
        {            
            foreach (var a in assentos)
            {
                if (a.IsReservado)
                {
                    Console.WriteLine("{0}: {1}",a.ToString(),a.Passageiro.Cpf);
                }
                else
                {
                    Console.WriteLine("{0}: null",a.ToString());
                }
            }
        }

    }
}
