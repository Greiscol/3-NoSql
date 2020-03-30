using MongoDB.Driver;
using MongoExample.Modelo.MisColecciones;
using MongoExample.Negocio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoExample.PruebaConsola
{
    class InvocadorMedico
    {
        private string nombreMedico;
        public void ConsultarMedicos()
        {
            CapturarInformacion();
            var listaMedicos = EjecutarConsulta(nombreMedico);
            ImprimirListaDeMedicos(listaMedicos);
        }

        private void ImprimirListaDeMedicos(IList<Medico> listaMedicos)
        {
            if (listaMedicos.Count > 0)
            {
                foreach (var item in listaMedicos)
                {
                    Console.WriteLine("Nombre: {0}  - Edad: {1} - Especialidad: {2}", item.nombre, item.edad, item.Especialidad);
                }
                string response = string.Empty;
                Console.Write("Desea consultar otro medico: ");
                response = Console.ReadLine();
                if (response=="yes")
                {
                    ConsultarMedicos();
                }
            }
            else
            {
                Console.WriteLine("No se encontraron medicos.");
                ConsultarMedicos();
            }
            ;
            Console.ReadLine();
        }

        private IList<Modelo.MisColecciones.Medico> EjecutarConsulta(string nombreMedico)
        {
            var elConsultante = new Medicos();
            var elResultado = elConsultante.ListarMedicosPorNombre(nombreMedico);
            return elResultado;
        }

        private void CapturarInformacion()
        {
            Console.Write("Digite el nombre del medico: ");
            nombreMedico = Console.ReadLine();
        }
    }
}
