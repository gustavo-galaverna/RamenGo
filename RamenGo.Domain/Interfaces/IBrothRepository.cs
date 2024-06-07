
using RamenGo.Domain.Entities;

namespace RamenGo.Domain.Interfaces
{
     public interface IBrothRepository
     {
        Task<IEnumerable<Broth>> GetAsync(); 
        Task<Broth> GetByIdAsync(string id); 

     }

}