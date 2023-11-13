using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnectionLogic
{
    public interface IMongoCommon : IMongoEntity<ObjectId>
    {
        string Name { get; set; }
        bool IsActive { get; set; }
        string Description { get; set; }
        DateTime Created { get; set; }
        DateTime Modified { get; set; }
    }
}
