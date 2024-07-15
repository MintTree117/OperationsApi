using OperationsDomain.Warehouse.Employees;
using OperationsDomain.Warehouse.Infrastructure;

namespace OperationsDomain.Warehouse.Operations.Receiving.Models;

public sealed class ReceivingOperations
{
    public Guid Id { get; private set; }
    public List<Trailer> Trailers { get; private set; } = [];
    public List<Area> Areas { get; private set; } = [];
    public List<Pallet> Pallets { get; private set; } = [];
    public List<ReceivingTask> PendingReceivingTasks { get; private set; } = [];
    public List<ReceivingTask> ActiveReceivingTasks { get; private set; } = [];
    
    // Shipping
    public bool ReceiveTrailerWithPallets( string trailerNumber, string dockNumber, List<Pallet> pallets )
    {
        return false;
    }
    
    // Tasks
    public ReceivingTask? GetNextReceivingTask() =>
        PendingReceivingTasks.FirstOrDefault();
    public ReceivingTask? StartReceivingTask( Employee employee, Guid taskId, Guid trailerId, Guid dockId, Guid areaId )
    {
        var task = PendingReceivingTasks
            .FirstOrDefault( t => t.Id == taskId );

        var stagingArea = Areas
            .FirstOrDefault( a => a.Id == areaId );

        var taskStarted = stagingArea is not null
            && task is not null
            && employee.StartReceivingTask( task, trailerId, dockId, stagingArea )
            && PendingReceivingTasks.Remove( task );

        if (taskStarted)
            ActiveReceivingTasks.Add( task! );

        return task;
    }
    public bool CompleteReceivingTask( Employee employee )
    {
        var receivingTask = employee
            .TaskAs<ReceivingTask>();
        
        return receivingTask.IsFinished
            && employee.EndTask()
            && ActiveReceivingTasks.Remove( receivingTask );
    }
}