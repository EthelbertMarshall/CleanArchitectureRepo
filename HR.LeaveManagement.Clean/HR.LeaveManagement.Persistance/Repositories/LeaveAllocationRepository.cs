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
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        public LeaveAllocationRepository(HRDatabaseContext dbContext) : base(dbContext)
        {
        }

        public async Task AddAllocations(List<LeaveAllocation> allocations)
        {
            await _dbContext.AddRangeAsync(allocations);      
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> AllocationsExists(string userId, int leaveTypeId, int period)
        {
            var result = await _dbContext.LeaveAllocations
                        .AnyAsync(a => a.EmployeeId == userId
                        && a.LeaveTypeId == leaveTypeId
                        && a.Period == period);

            return result;
        }

        public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id)
        {
            var result = await _dbContext.LeaveAllocations
                                .Include(a => a.LeaveType)
                                .FirstOrDefaultAsync(a => a.Id == id);
            return result;
                                
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails()
        {
            var result = await _dbContext.LeaveAllocations
                               .Include(a => a.LeaveType).ToListAsync();

            return result;
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails(string userId)
        {
            var result = await _dbContext.LeaveAllocations.Where(a => a.EmployeeId == userId)
                            .Include(a => a.LeaveType)
                            .ToListAsync();
            return result;
        }

        public async Task<LeaveAllocation> GetUserAllocations(string userId, int leaveTypeId)
        {
            var result = await _dbContext.LeaveAllocations
                                .FirstOrDefaultAsync( a=> a.EmployeeId == userId && a.LeaveTypeId == leaveTypeId);
            return result;  
        }
    }
}
