
namespace BAL
{
    public interface IConsumerBAL
    {
        Task<bool> StartConsumingAsync(CancellationToken cancellationToken);
    }
}
