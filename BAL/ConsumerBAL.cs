using DAL; 
namespace BAL
{
    public  class ConsumerBAL:IConsumerBAL
    {
        private readonly IConsumerDAL _consumerDAL;

        public ConsumerBAL(IConsumerDAL consumerDAL)
        { 
            _consumerDAL = consumerDAL;
        }

        public async Task<bool> StartConsumingAsync(CancellationToken cancellationToken)
        { 
            await _consumerDAL.StartConsumingAsync(cancellationToken);
            return true;
        }
    }
}
