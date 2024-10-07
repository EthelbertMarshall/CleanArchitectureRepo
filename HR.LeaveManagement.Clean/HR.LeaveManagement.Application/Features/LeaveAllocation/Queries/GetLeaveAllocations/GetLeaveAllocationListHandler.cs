using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocations
{
    public class GetLeaveAllocationListHandler : IRequestHandler<GetLeaveAllocationListQuery,
        List<LeaveAllocationDto>>
    {
        //private readonly IAppLogger<GetLeaveAllocationListQuery> _logger;
        private readonly IMapper _mapper;
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        public GetLeaveAllocationListHandler(IMapper mapper, ILeaveAllocationRepository leaveAllocationRepository)
        {
            _mapper = mapper;
            _leaveAllocationRepository = leaveAllocationRepository;
        }

        public async Task<List<LeaveAllocationDto>> Handle(GetLeaveAllocationListQuery request, 
            CancellationToken cancellationToken)
        {
            //Get records for Specific User
            //Get Allocations per Employee

            var leaveAllocations = await _leaveAllocationRepository.GetLeaveAllocationWithDetails();

            var allocations = _mapper.Map<List<LeaveAllocationDto>>(leaveAllocations);

            return allocations;

        }
    }
}
