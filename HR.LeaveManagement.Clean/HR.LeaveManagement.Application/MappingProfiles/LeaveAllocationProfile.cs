using AutoMapper;
using HR.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetails;
using HR.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocations;

namespace HR.LeaveManagement.Application.MappingProfiles
{
    public class LeaveAllocationProfile : Profile
    {
        public LeaveAllocationProfile()
        {
            CreateMap<LeaveAllocationDto, LeaveAllocationProfile>().ReverseMap();
            CreateMap<LeaveAllocationProfile, LeaveAllocationDetailsDto>();
            //CreateMap<UpdateLeaveAllocationCommand, LeaveAllocation>();
            //CreateMap<CreateLeaveAllocationCommand, LeaveAllocation>();
        }
    }
}
