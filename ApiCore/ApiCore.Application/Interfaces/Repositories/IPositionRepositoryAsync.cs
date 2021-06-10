using ApiCore.Application.Features.Positions.Queries.GetPositions;
using ApiCore.Application.Parameters;
using ApiCore.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiCore.Application.Interfaces.Repositories
{
    public interface IPositionRepositoryAsync : IGenericRepositoryAsync<Position>
    {
        Task<bool> IsUniquePositionNumberAsync(string positionNumber);

        Task<bool> SeedDataAsync(int rowCount);

        Task<(IEnumerable<Entity> data, RecordsCount recordsCount)> GetPagedPositionReponseAsync(GetPositionsQuery requestParameters);
    }
}
