using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoExample.Modelo.MisColecciones
{

    
    [BsonIgnoreExtraElements]
    public class Medico
    {
        [BsonId]
        public ObjectId id;
        [BsonElement("nombre")]
        public string nombre { get; set; }
        [BsonElement("años")]
        public string  edad { get; set; }
        [BsonElement("especialidad")]
        public string Especialidad { get; set; }
        [BsonElement("detalles")]
        public Detalles LosDetalles { get; set; }
        [BsonElement("operaciones")]
        public string[] operaciones { get; set; }
        [BsonIgnore] 
        [BsonExtraElements] public BsonDocument Metadata { get; set; }
    }

    public class Detalles
    {
        [BsonElement("residencia")]
        public string Residencia { get; set; }
        [BsonElement("provincia")]
        public string Provincia { get; set; }
        [BsonExtraElements] public BsonDocument Metadata { get; set; }

    }
}
