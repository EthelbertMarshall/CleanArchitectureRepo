using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            this._mapper = mapper;   
            this._leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            //Validate Incoming Data

            var validator = new CreateLeaveTypeCommandValidator(_leaveTypeRepository);
            var validationresult = await validator.ValidateAsync(request, cancellationToken);

            if (validationresult.Errors.Any())
                throw new BadRequestException("Invalid leaveType", validationresult);

            // Convert to Domain Entity Object 

            var leaveTypeToCreate = _mapper.Map<Domain.LeaveType>(request);

            var result = await _leaveTypeRepository.CreateAsync(leaveTypeToCreate);

            //Add to Database

            //Return Record Id
            return leaveTypeToCreate.Id;   // Try using result.Id

        }
    }
}
