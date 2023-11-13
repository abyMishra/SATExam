using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnectionLogic
{
    public interface IMyDatabase<T>
    {
        IMongoDatabase Database { get; }
        IMongoCollection<T> Collection { get; }
    }
}
