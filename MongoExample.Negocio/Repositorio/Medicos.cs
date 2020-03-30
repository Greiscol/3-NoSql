using MongoDB.Bson;
using MongoDB.Driver;
using MongoExample.Modelo.MisColecciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoExample.Negocio.Repositorio
{


    public class Medicos
    {
        private const string _collName = "medicos";
        private const string _dbName = "hospital";

        private IMongoCollection<Medico> ObtenerColeccionDeMedicos()
        {
            var laConexion = new Conexion();
            var db = laConexion.GetDatabaseReference("localhost", _dbName);
            var collection = db.GetCollection<Medico>(_collName);
            return collection;
        }

        public IList<Medico> ListarTodos
            (string nombreDelHost, string dbName)
        {

            var elCliente = new Conexion();
            var laBaseDeDatos = elCliente.GetDatabaseReference(nombreDelHost, dbName);
            var laColeccion = laBaseDeDatos.GetCollection<Medico>("medicos");
            var filter = new BsonDocument();
            var elResultado = laColeccion.Find<Medico>(filter).ToList();
            //IList<Animalito> laLista = new List<Animalito>();
            return elResultado;
        }

        public IList<Medico> ListarMedicosPorNombre(string elNombre)
        {
            var losMedicos = ObtenerColeccionDeMedicos();
            /* Filter to retrieve movies where the name equals to "elNombre" */
            var expresssionFilter = Builders<Medico>.Filter.Eq(x => x.nombre, elNombre);
            var result = losMedicos.Find(expresssionFilter).ToList();
            return result;
        }

        private Medico ObtenerAnimalitoPorId(ObjectId idDelMedico)
        {
            var losMedicos = ObtenerColeccionDeMedicos();
            /* Filter to retrieve movies where the name equals to "elNombre" */
            var expresssionFilter = Builders<Medico>.Filter.Eq(x => x.id, idDelMedico);
            var elMedico = losMedicos.Find(expresssionFilter).ToList().FirstOrDefault();
            return elMedico;
        }

    }
}
