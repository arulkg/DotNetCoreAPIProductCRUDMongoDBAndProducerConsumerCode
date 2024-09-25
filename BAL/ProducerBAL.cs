using BOL;
using DAL;

namespace BAL
{
    public class ProducerBAL:IProducerBAL
    {
        private readonly IProducerDAL _producerDAL;

        public ProducerBAL(IProducerDAL producerDAL)
        { 
            _producerDAL = producerDAL;
        }

        public async Task<bool> Insert(TaskMessage payload)
        { 
            await _producerDAL.Insert(payload);
            return true;
        }
    }
}
