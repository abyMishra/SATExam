using CommonLibrary;
using DataModels.Common;
using DataModels.Destination;
using DestinationService.BusinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace DestinationService.Controllers
{
    [Route("api/Destination")]
    [ApiController]
    public class DestinationController : ControllerBase
    {
        private IDestinationBusinessLogic _destinationBusinessLogic;

        private readonly ILogger<DestinationController> _logger;

        public DestinationController(IDestinationBusinessLogic destinationBusinessLogic, ILogger<DestinationController> logger)
        {
            _destinationBusinessLogic = destinationBusinessLogic;
            _logger = logger;
        }

        [HttpPost("AddDestination")]
        public IActionResult AddDestination(DestinationMaster destination) {
            _logger.LogInformation("Adding Destination");
            var result = _destinationBusinessLogic.AddDestination(destination);
            _logger.LogInformation("Destination Added with id:"+ result.Id);
            if (result == null)
            {
                _logger.LogError("Error in adding Destination");
                return BadRequest(new { message = "Destination is not added. Please refer to logs for more details." });
            }

            return Ok(result);
        }

        [HttpPost("UpdateDestinationImages")]
        public IActionResult UpdateDestinationImages(DestinationMaster destination)
        {
            var result = _destinationBusinessLogic.UpdateDestinationImages(destination);

            if (result == null)
                return BadRequest(new { message = "Destination images are not added/updated. Please refer to logs for more details." });

            return Ok(result);
        }

        [HttpPost("UpdateGeneralInformation")]
        public IActionResult UpdateGeneralInformation(DestinationMaster destination)
        {
            var result = _destinationBusinessLogic.UpdateGeneralInformation(destination);

            if (result == null)
                return BadRequest(new { message = "Destination general information is not added/updated. Please refer to logs for more details." });

            return Ok(result);
        }

        [HttpGet("GetAllDestinations")]
        public IActionResult GetAllDestinations()
        {
            var result = _destinationBusinessLogic.GetAllDestinations();

            if (result == null)
                return BadRequest(new { message = "Destination information is not available. Please refer to logs for more details." });

            return Ok(result);
        }

        [HttpDelete("DeleteDestination")]
        public IActionResult DeleteDestination(string objectId)
        {
            var result = _destinationBusinessLogic.DeleteDestination(objectId);

            if (!result)
                return BadRequest(new { message = "Destination not deleted. Please refer to logs for more details." });

            return Ok(result);
        }

        [HttpPost("DeleteTaxInfo")]
        public IActionResult DeleteTaxInfo(TaxMaster tax)
        
        {
            var data = Request.Query.ToArray();
            string destinationId = data[0].Value.ToString();
            var result = _destinationBusinessLogic.DeleteTaxInfo(destinationId, tax);

            if (!result)
                return BadRequest(new { message = "Tax information not deleted. Please refer to logs for more details." });

            return Ok(result);
        }
    }
}
