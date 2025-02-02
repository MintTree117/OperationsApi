using OperationsApi.Endpoints.Dtos;
using OperationsDomain.Operations.Putaways.Models;

namespace OperationsApi.Endpoints.Putaways.Dtos;

internal readonly record struct PutawayTaskSummary(
    Guid PalletId,
    RackingDto Racking )
{
    internal static PutawayTaskSummary FromModel( PutawayTask model ) =>
        new( model.PalletId, RackingDto.FromModel( model.PutawayRacking ) );
}