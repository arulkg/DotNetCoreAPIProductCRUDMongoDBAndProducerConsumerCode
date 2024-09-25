using BAL;
using BOL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProducerCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducerController : ControllerBase
    {
        private readonly IProducerBAL _producerBAL;

        public ProducerController(IProducerBAL producerBAL)
        { 
            _producerBAL = producerBAL;
        }
        [HttpPost]
        public async Task<IActionResult> Produce([FromBody] string payload) {
            try
            {
                var taskMessage = new TaskMessage
                {
                    Payload = payload,
                    Status = "Pending"
                };

                await _producerBAL.Insert(taskMessage); 

                return Ok( new { message="Task produced",id = taskMessage.Id });

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
