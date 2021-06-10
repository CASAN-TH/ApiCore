using ApiCore.Application.Features.Employees.Queries.GetEmployees;
using ApiCore.Application.Parameters;
using ApiCore.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiCore.Application.Interfaces.Repositories
{
    public interface IEmployeeRepositoryAsync : IGenericRepositoryAsync<Employee>
    {
        Task<(IEnumerable<Entity> data, RecordsCount recordsCount)> GetPagedEmployeeReponseAsync(GetEmployeesQuery requestParameter);
    }
}
