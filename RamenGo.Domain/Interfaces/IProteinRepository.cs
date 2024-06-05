using RamenGo.Domain.Entities;

namespace RamenGo.Domain.Interfaces
{
     public interface IProteinRepository
     {
        Task<IEnumerable<Protein>> GetAsync(); 
        Task<Protein?> GetByIdAsync(string id); 
     }

}