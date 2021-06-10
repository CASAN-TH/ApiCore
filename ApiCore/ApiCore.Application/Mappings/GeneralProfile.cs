using ApiCore.Application.Features.Employees.Queries.GetEmployees;
using ApiCore.Application.Features.Positions.Commands.CreatePosition;
using ApiCore.Application.Features.Positions.Queries.GetPositions;
using ApiCore.Domain.Entities;
using AutoMapper;

namespace ApiCore.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Position, GetPositionsViewModel>().ReverseMap();
            CreateMap<Employee, GetEmployeesViewModel>().ReverseMap();
            CreateMap<CreatePositionCommand, Position>();
        }
    }

}
