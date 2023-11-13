using CommonLibrary;
using DataModels.Common;
using DataModels.Destination;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using static MongoDB.Driver.WriteConcern;

namespace DestinationService.DataAccess
{
    public class DestinationDataAccess
    {
        private readonly IMongoCollection<DestinationMaster> _destinationlistCollection;
        private readonly ICommonMethods _commonMethods;

        public DestinationDataAccess(IOptions<DBSettings> dbSettings, ICommonMethods commonMethods)
        {
            MongoClient client = new MongoClient(dbSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(dbSettings.Value.DatabaseName);
            _destinationlistCollection = database.GetCollection<DestinationMaster>(dbSettings.Value.CollectionName);
            _commonMethods = commonMethods;
        }

        public List<DestinationMaster> GetAllDestinations()
        {
            List<DestinationMaster> destinationList = new List<DestinationMaster>();
            var filter = Builders<DestinationMaster>.Filter.Empty;
            try
            {
                destinationList = _destinationlistCollection.AsQueryable().ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return destinationList;
        }

        public DestinationMaster AddDestination(DestinationMaster destination)
        {
            try
            {
                _destinationlistCollection.InsertOne(destination);
            }
            catch (Exception ex)
            {
                throw;
            }
            return destination;
        }

        public DestinationMaster UpdateGeneralInformation(DestinationMaster destination)
        {
            try
            {
                var filter = Builders<DestinationMaster>.Filter.Eq("_id", ObjectId.Parse(destination.Id));
                var update = Builders<DestinationMaster>.Update.Set(data => data.DestinationName, destination.DestinationName)
                    .Set(data => data.DestinationCode, destination.DestinationCode)
                    .Set(data => data.DestinationDescription, destination.DestinationDescription)
                    .Set(data => data.CountryDetailsID, destination.CountryDetailsID)
                    .Set(data => data.IsActive, destination.IsActive)
                    .Set(data => data.Location, destination.Location)
                    .Set(data => data.TaxDetails, destination.TaxDetails);
                var updObj = _destinationlistCollection.Find(filter).FirstOrDefaultAsync();
                _destinationlistCollection.UpdateOne(filter, update);
            }
            catch (Exception ex)
            {
                throw;
            }
            return destination;
        }

        public DestinationMaster UpdateDestinationImages(DestinationMaster destination)
        {
            try
            {
                var filter = Builders<DestinationMaster>.Filter.Eq("_id", ObjectId.Parse(destination.Id));
                var update = Builders<DestinationMaster>.Update.Set(data => data.DestinationImage, destination.DestinationImage);
                _destinationlistCollection.UpdateOne(filter, update);
            }
            catch (Exception ex)
            {
                throw;
            }
            return destination;
        }

        public bool DeleteDestination(string objectId)
        {
            bool isDeleted = false;
            try
            {
                //var isSucess = false;
                //var filter = DestinationMaster;
                //foreach (var destination in destinationList)
                //{
                //    filter = Builders<DestinationMaster>.Filter.Eq("_id", ObjectId.Parse(destination.Id));
                //    isSucess = _destinationlistCollection.DeleteOne(filter);
                //}
                var filter = Builders<DestinationMaster>.Filter.Eq("_id", ObjectId.Parse(objectId));
                var isSucess = _destinationlistCollection.DeleteOne(filter);
                isDeleted = isSucess.DeletedCount > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw;
            }
            return isDeleted;
        }

        public bool DeleteTaxInfo(string destinationId, TaxMaster tax)
        {
            bool isDeleted = false;
            DestinationMaster _destination = null;
            try
            {
                var filter = Builders<DestinationMaster>.Filter.Eq("_id", ObjectId.Parse(destinationId));
                _destination = _destinationlistCollection.Find<DestinationMaster>(filter).FirstOrDefault();
                if (_destination != null && _destination.TaxDetails != null)
                    isDeleted = _destination.TaxDetails.Remove(tax);
                else
                    isDeleted = false;
            }
            catch (Exception ex)
            {
                throw;
            }
            return isDeleted;
        }
    }
}
