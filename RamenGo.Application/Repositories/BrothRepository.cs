using Microsoft.EntityFrameworkCore;
using RamenGo.Data;
using RamenGo.Domain.Entities;
using RamenGo.Domain.Interfaces;

namespace RamenGo.Application.Repositories
{
    public class BrothRepository : IBrothRepository
    {
        private readonly RamenGoDbContext _ramenGoDbContext;
        public BrothRepository(RamenGoDbContext ramenGoDbContext) => _ramenGoDbContext = ramenGoDbContext;
        public async Task<IEnumerable<Broth>> GetAsync()
        {
            return await _ramenGoDbContext.Broths.ToListAsync();
        }

        public async Task<Broth?> GetByIdAsync(string id)
        {
            return await _ramenGoDbContext.Broths.FirstOrDefaultAsync(b => b.Id == id);
        }
    }
}