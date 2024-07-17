using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OperationsDomain._Database;
using OperationsDomain.Warehouse.Operations.Picking.Models;

namespace OperationsDomain.Warehouse.Operations.Picking;

internal class PickingRepository( WarehouseDbContext dbContext, ILogger<PickingRepository> logger ) 
    : DatabaseService<PickingRepository>( dbContext, logger ), IPickingRepository
{
    public async Task<PickingOperations?> GetPickingOperationsWithTasks()
    {
        try
        {
            return await DbContext.Picking
                .Include( static p => p.PendingPickingTasks )
                .Include( static p => p.ActivePickingTasks )
                .FirstOrDefaultAsync()
                .ConfigureAwait( false );
        }
        catch ( Exception e )
        {
            return ProcessDbException<PickingOperations?>( e, null );
        }
    }
    public async Task<PickingOperations?> GetPickingOperationsWithEvents()
    {
        try
        {
            return await DbContext.Picking
                .Include( static p => p.ReplenishEvents )
                .FirstOrDefaultAsync()
                .ConfigureAwait( false );
        }
        catch ( Exception e )
        {
            return ProcessDbException<PickingOperations?>( e, null );
        }
    }
}