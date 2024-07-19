using OperationsDomain.Warehouse.Infrastructure.Units;
using OperationsDomain.Warehouse.Operations.Putaways.Models;

namespace OperationsDomain.Warehouse.Employees.Models;

public sealed class PutawayEmployee : Employee
{
    public PutawayEmployee( Guid id, string name, Pallet? palletEquipped, PutawayTask? task ) 
        : base( id, name, palletEquipped, task ) { }
    public PutawayTask? PutawayTask => TaskAs<PutawayTask>();
    
    public async Task<bool> StartPutaway( PutawayOperations putaways, Guid palletId )
    {
        if (Task is not null)
            return false;

        var putawayTask = await putaways.GenerateTask( palletId );

        return putawayTask is not null
            && StartTask( putawayTask )
            && putawayTask.Initialize( this )
            && putaways.ActivateTask( putawayTask )
            && UnStagePallet( putawayTask.PickupArea, putawayTask.Pallet );
    }
    public bool FinishPutaway( PutawayOperations putaways, Guid rackingId, Guid palletId )
    {
        return PutawayTask is not null
            && PutawayTask.ConfirmPutaway( rackingId, palletId )
            && RackPallet( PutawayTask.PutawayRacking, PutawayTask.Pallet )
            && PutawayTask.CleanUp( this )
            && putaways.FinishPutawayTask( PutawayTask );
    }
}