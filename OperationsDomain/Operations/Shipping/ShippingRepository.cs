using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OperationsDomain._Database;
using OperationsDomain.Operations.Shipping.Models;

namespace OperationsDomain.Operations.Shipping;

internal sealed class ShippingRepository( WarehouseDbContext dbContext, ILogger<ShippingRepository> logger ) 
    : DatabaseService<ShippingRepository>( dbContext, logger ), IShippingRepository
{
    public async Task<ShippingOperations?> GetShippingOperationsWithRoutes()
    {
        try
        {
            return await DbContext.Shipping
                .FirstOrDefaultAsync()
                .ConfigureAwait( false );
        }
        catch ( Exception e )
        {
            return ProcessDbException<ShippingOperations?>( e, null );
        }
    }
}