using OperationsApi.Domain.Employees;

namespace OperationsApi.Domain.Warehouses;

internal sealed class Pallet
{
    public Guid Id { get; private set; }
    public Guid OwnerId { get; set; }
    public Guid ReceivedById { get; private set; }
    public Guid AreaId { get; private set; }
    public Guid RackingId { get; private set; }
    public Employee? Owner { get; set; }
    public Employee? ReceivedBy { get; private set; }
    public Area? Area { get; private set; }
    public Racking? Racking { get; private set; }
    public double Length { get; set; }
    public double Width { get; set; }
    public double Height { get; set; }
    public double Weight { get; set; }

    public bool IsOwned() => 
        Owner is not null;
    public bool IsOwnedBy( Employee employee ) =>
        Owner == employee;
    public bool IsReceived() => 
        ReceivedBy is not null;
    public bool IsCorrectArea( Guid areaId ) =>
        AreaId == areaId;

    void SetOwner( Employee? employee )
    {
        Owner = employee;
        OwnerId = employee?.Id ?? Guid.Empty;
    }
    void SetArea( Area? area )
    {
        Area = area;
        AreaId = area?.Id ?? Guid.Empty;
    }
    void SetRacking( Racking? racking )
    {
        Racking = racking;
        RackingId = racking?.Id ?? Guid.Empty;
    }
    
    public bool Receive( Employee employee )
    {
        if (IsOwned() || IsReceived())
            return false;

        ReceivedBy = employee;
        ReceivedById = employee.Id;
        AssignTo( employee );
        return true;
    }
    public void AssignTo( Employee employee )
    {
        SetArea( null );
        SetRacking( null );
        SetOwner( employee );
    }
    public void AssignTo( Racking racking )
    {
        SetOwner( null );
        RackingId = racking.Id;
        Racking = racking;
    }
    public bool Stage( Area area )
    {
        if (!IsReceived())
            return false;
        
        SetArea( area );
        SetOwner( null );
        return true;
    }
}