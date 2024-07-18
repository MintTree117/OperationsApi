using Microsoft.EntityFrameworkCore;
using OperationsDomain.Ordering.Models;
using OperationsDomain.Shipping.Models;
using OperationsDomain.Warehouse;
using OperationsDomain.Warehouse.Employees.Models;
using OperationsDomain.Warehouse.Equipment;
using OperationsDomain.Warehouse.Infrastructure;
using OperationsDomain.Warehouse.Infrastructure.Units;
using OperationsDomain.Warehouse.Operations.Loading.Models;
using OperationsDomain.Warehouse.Operations.Picking.Models;
using OperationsDomain.Warehouse.Operations.Putaways.Models;
using OperationsDomain.Warehouse.Operations.Receiving.Models;

namespace OperationsDomain._Database;

public class WarehouseDbContext( DbContextOptions<WarehouseDbContext> options ) 
    : DbContext( options )
{
    protected override void OnModelCreating( ModelBuilder modelBuilder )
    {
        
    }
    
    // TASKS
    public required DbSet<LoadingTask> PendingLoadingTasks { get; init; }
    public required DbSet<PickingTask> PendingPickingTasks { get; init; }
    public required DbSet<PutawayTask> PendingPutawayTasks { get; init; }
    public required DbSet<ReceivingTask> PendingReceivingTasks { get; init; }
    
    public required DbSet<LoadingTask> ActiveLoadingTasks { get; init; }
    public required DbSet<PickingTask> ActivePickingTasks { get; init; }
    public required DbSet<PutawayTask> ActivePutawayTasks { get; init; }
    public required DbSet<ReceivingTask> ActiveReceivingTasks { get; init; }
    
    // SHIPPING
    public required DbSet<ShippingOperations> Shipping { get; init; }
    
    // ORDERS
    public required DbSet<OrderingOperations> Ordering { get; init; }
    public required List<WarehouseOrder> PendingOrders { get; init; }
    public required List<WarehouseOrder> ActiveOrders { get; init; }
    public required List<WarehouseOrder> PickedOrders { get; init; }
    
    // WAREHOUSE
    public required DbSet<Root> Warehouses { get; init; }
    public required DbSet<ReceivingOperations> Receiving { get; set; }
    public required DbSet<PutawayOperations> Putaways { get; set; }
    public required DbSet<PickingOperations> Picking { get; set; }
    public required DbSet<LoadingOperations> Loading { get; set; }
    public required DbSet<Trailer> Trailers { get; init; }
    public required DbSet<Dock> Docks { get; init; }
    public required DbSet<Area> Areas { get; init; }
    public required DbSet<Racking> Rackings { get; init; }
    public required DbSet<Pallet> Pallets { get; init; }
    public required DbSet<Employee> Employees { get; init; }
    public required DbSet<Forklift> Forklifts { get; init; }
    public required DbSet<Scanner> Scanners { get; init; }
}