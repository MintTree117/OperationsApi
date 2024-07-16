using OperationsDomain.Warehouse.Infrastructure;

namespace OperationsDomain.Warehouse.Operations.Putaways.Models;

public sealed class PutawayTask : WarehouseTask
{
    public Pallet Pallet { get; private set; } = null!;
    public Area PickupArea { get; private set; } = null!;
    public Racking PutawayRacking { get; private set; } = null!;
    public Guid PalletId { get; private set; }
    public Guid PickupAreaId { get; private set; }
    public Guid PutawayRackingId { get; private set; }
    
    internal bool InitializePutaway( Racking racking, Pallet pallet )
    {
        bool canStart = pallet.CanBePutaway();
        if (!canStart)
            return false;
        
        Pallet = pallet;
        PalletId = pallet.Id;
        PickupArea = pallet.Area!;
        PickupAreaId = pallet.AreaId!.Value;
        PutawayRacking = racking;
        PutawayRackingId = racking.Id;
        
        return true;
    }

    internal bool CompletePutaway( Guid rackingId, Guid palletId )
    {
        IsFinished = rackingId != PutawayRacking.Id
            && palletId != Pallet.Id;

        return IsFinished;
    }
}