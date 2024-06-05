using Microsoft.EntityFrameworkCore;
using RamenGo.Data;
using RamenGo.Domain.Entities;
using RamenGo.Domain.Interfaces;

namespace RamenGo.Application.Repositories
{
    public class ProteinRepository : IProteinRepository
    {
        private readonly RamenGoDbContext _ramenGoDbContext;
        public ProteinRepository(RamenGoDbContext ramenGoDbContext) => _ramenGoDbContext = ramenGoDbContext;
        public async Task<IEnumerable<Protein>> GetAsync()
        {
            return await _ramenGoDbContext.Proteins.ToListAsync();
        }

        public async Task<Protein?> GetByIdAsync(string id)
        {
            return await _ramenGoDbContext.Proteins.FirstOrDefaultAsync(b => b.Id == id); 
        }
    }
}