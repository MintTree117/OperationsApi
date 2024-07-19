using OperationsDomain.Warehouse.Infrastructure.Units;
namespace OperationsDomain.Shipping.Models;

public sealed class ShippingOperations
{
    public Guid Id { get; private set; }
    public List<Trailer> Trailers { get; private set; } = [];
    public List<Dock> Docks { get; private set; } = [];

    public Trailer? FindAvailableTrailer() =>
        Trailers.FirstOrDefault( static t => t.State is TrailerState.Parked );
    public Dock? FindAvailableDock() =>
        Docks.FirstOrDefault( static d => !d.IsOwned() );
}