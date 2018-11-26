using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservasDeVoos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Trabalho de POO\n\n");
            Reservas r = new Reservas();
            Console.Write("Número de vagas a serem preenchidas: ");
            Console.WriteLine(r.vagasRemanescentesTotal());
            r.imprimirReservas(3001);
            

            Console.ReadKey();
        }
    }
}
