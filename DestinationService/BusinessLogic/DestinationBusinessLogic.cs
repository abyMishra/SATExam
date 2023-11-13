using DataModels.Common;
using DataModels.Destination;
using DestinationService.DataAccess;
using Microsoft.Extensions.Options;

namespace DestinationService.BusinessLogic
{
    public class DestinationBusinessLogic : IDestinationBusinessLogic
    {
        private readonly DestinationDataAccess _destinatoinDataAcess;

        public DestinationBusinessLogic(DestinationDataAccess destinationDataAcess)
        {
            _destinatoinDataAcess = destinationDataAcess;
        }

        public List<DestinationMaster> GetAllDestinations()
        {
            try
            {
                return _destinatoinDataAcess.GetAllDestinations();
            }
            catch (Exception ex)
            {
                // Log exception here to the logger
                throw;
            }
        }

        public DestinationMaster AddDestination(DestinationMaster destination)
        {
            try
            {
                return _destinatoinDataAcess.AddDestination(destination);
            }
            catch (Exception ex)
            {
                // Log exception here to the logger
                throw;
            }
        }

        public DestinationMaster UpdateDestinationImages(DestinationMaster destination)
        {
            try
            {
                return _destinatoinDataAcess.UpdateDestinationImages(destination);
            }
            catch (Exception ex)
            {
                // Log exception here to the logger
                throw;
            }
        }

        public DestinationMaster UpdateGeneralInformation(DestinationMaster destination)
        {
            try
            {
                return _destinatoinDataAcess.UpdateGeneralInformation(destination);
            }
            catch (Exception ex)
            {
                // Log exception here to the logger
                throw;
            }
        }

        public bool DeleteDestination(string objectId)
        {
            try
            {
                return _destinatoinDataAcess.DeleteDestination(objectId);
            }
            catch (Exception ex)
            {
                // Log exception here to the logger
                throw;
            }
        }

        public bool DeleteTaxInfo(string destinationId, TaxMaster tax)
        {
            try
            {
                return _destinatoinDataAcess.DeleteTaxInfo(destinationId, tax);
            }
            catch (Exception ex)
            {
                // Log exception here to the logger
                throw;
            }
        }
    }
}
