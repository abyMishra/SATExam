using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DatabaseConnectionLogic
{
    public class GlobalLogic<TCollection, TContext>
 where TCollection : IMongoCommon
 where TContext : IMongoCommon, new()
    {
        public async Task<IEnumerable<TCollection>> GetAllAsync(IMongoCollection<TCollection> collection)
        {
            return await collection.Find(f => true).ToListAsync();
        }

        public async Task<TCollection> GetOneAsync(IMongoCollection<TCollection> collection, TContext context)
        {
            return await collection.Find(new BsonDocument("_id", context.Id)).FirstOrDefaultAsync();
        }

        public async Task<TCollection> GetOneAsync(IMongoCollection<TCollection> collection, string id)
        {
            return await GetOneAsync(collection, new TContext { Id = new ObjectId(id) });
        }

        public async Task<IEnumerable<TCollection>> GetManyAsync(IMongoCollection<TCollection> collection,
                                                                 IEnumerable<TContext> contexts)
        {
            var list = new List<TCollection>();
            foreach (var context in contexts)
            {
                var doc = await GetOneAsync(collection, context);
                if (doc == null) continue;
                list.Add(doc);
            }

            return list;
        }

        public async Task<IEnumerable<TCollection>> GetManyAsync(IMongoCollection<TCollection> collection,
                                                                 IEnumerable<string> ids)
        {
            var list new List<TCollection();
            foreach (var id in ids)
            {
                var doc = await GetOneAsync(collection, id);
                if (doc == null) continue;
                list.Add(doc);
            }

            return list;
        }

        public async Task<bool> RemoveOneAsync(IMongoCollection<TCollection> collection, TContext context)
        {
            if (context == null || string.IsNullOrEmpty(context.Name)) return false;
            await collection.UpdateOneAsync(
            new BsonDocument("_id", context.Id),
            new BsonDocument("$set", new BsonDocument { { nameof(IMongoCommon.IsActive, false },
                                                 { nameof(IMongoCommon.Modified), DateTime.UtcNow } }));
            return true;
        }

        public Task<bool> RemoveOneAsync(IMongoCollection<TCollection> collection, string id)
        {
            return await RemoveOneAsync(collection, new TContext { Id = new ObjectId(id) });
        }

        public async Task<bool> RemoveManyAsync(IMongoCollection<TCollection> collection,
                                                IEnumerable<TContext> contexts)
        {
            foreach (var context in contexts)
                await RemoveOneAsync(collection, context);
            return true;
        }

        public async Task<bool> RemoveManyAsync(IMongoCollection<TCollection> collection,
                                                IEnumerable<string> ids)
        {
            foreach (var id in ids)
                await RemoveOneAsync(collection, id);
            return true;
        }
    }
}
