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
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        public LeaveRequestRepository(HRDatabaseContext dbContext) : base(dbContext)
        {
        }

        public async Task<LeaveRequest> GetLeaveRequestWithDetails(int id)
        {
            var result = await _dbContext.LeaveRequests                                
                                .Include( a => a.LeaveType )
                                .FirstOrDefaultAsync(a=>a.Id == id);
            return result;
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestWithDetails()
        {
            var result = await _dbContext.LeaveRequests
                                .Include(a=>a.LeaveType)
                                .ToListAsync();
            return result;
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestWithDetails(string userid)
        {
            var result = await _dbContext.LeaveRequests
                                .Where(a => a.RequestingEmployeeId == userid)
                                .Include(a => a.LeaveType)
                                .ToListAsync();
            return result;
        }
    }
}
