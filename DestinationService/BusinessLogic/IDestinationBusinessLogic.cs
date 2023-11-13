using DataModels.Common;
using DataModels.Destination;

namespace DestinationService.BusinessLogic
{
    public interface IDestinationBusinessLogic
    {
        List<DestinationMaster> GetAllDestinations();
        DestinationMaster AddDestination(DestinationMaster destination);
        DestinationMaster UpdateGeneralInformation(DestinationMaster destination);
        DestinationMaster UpdateDestinationImages(DestinationMaster destination);

        bool DeleteDestination(string objectId);
        bool DeleteTaxInfo(string destinationId, TaxMaster tax);
    }
}
