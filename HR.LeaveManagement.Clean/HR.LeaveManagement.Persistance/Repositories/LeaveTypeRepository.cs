using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Persistance.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Persistance.Repositories
{
    public class LeaveTypeRepository :  GenericRepository<LeaveType>, ILeaveTypeRepository

    {
        public LeaveTypeRepository(HRDatabaseContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> IsLeaveTypeNameUnique(string name)
        {
            return await _dbContext.LeaveTypes.AnyAsync(a => a.Name  == name) == false;   
        }
    }
}
