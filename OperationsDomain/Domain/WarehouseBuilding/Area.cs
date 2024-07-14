namespace OperationsDomain.Domain.WarehouseBuilding;

public sealed class Area
{
    public Guid Id { get; private set; }
    public string Number { get; private set; } = string.Empty;
    public bool IsAvailable { get; set; }
    public List<Pallet> Pallets { get; set; } = [];

    public bool TakePallet( Pallet pallet )
    {
        bool staged = IsAvailable
            && !Pallets.Contains( pallet );

        if (staged)
            Pallets.Add( pallet );

        return staged;
    }

    public bool CanUse()
    {
        return IsAvailable;
    }
}