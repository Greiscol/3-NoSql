using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoExample.PruebaConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            DoJobMedico();
        }

        private static void DoJobMedico()
        {
            var elInvocador = new InvocadorMedico();
            elInvocador.ConsultarMedicos();
        }


    }
}
