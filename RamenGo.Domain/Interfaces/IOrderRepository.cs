
using RamenGo.Domain.DTO;
using RamenGo.Domain.Entities;

namespace RamenGo.Domain.Interfaces
{
     public interface IOrderRepository
     {
        Task<OrderResponse> PlaceOrder(string brothId, string proteinId); 

     }

}