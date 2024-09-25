using BAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsumerCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumerController : ControllerBase
    {
        private readonly IConsumerBAL _consumerBAL;
        private CancellationTokenSource _cancellationTokenSource;


        public ConsumerController(IConsumerBAL consumerBAL)
        { 
            _consumerBAL = consumerBAL;
            _cancellationTokenSource = new CancellationTokenSource();
        }

        [HttpPost("StartConsuming")]
        public IActionResult StartConsuming()
        {
            try
            {
                Task.Run(() => _consumerBAL.StartConsumingAsync(_cancellationTokenSource.Token));
                return Ok(new { message = "Consumer started" });
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost("StopConsuming")]
        public IActionResult StopConsuming()
        {
            try
            {
                _cancellationTokenSource.Cancel();
                return Ok(new { message = "Consumer stopped" });

            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}
