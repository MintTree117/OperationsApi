namespace OperationsDomain.Ordering.Models;

public enum OrderStatus
{
    Pending,
    Fulfilling,
    Loading,
    Shipped,
    Delivered,
    Returned
}