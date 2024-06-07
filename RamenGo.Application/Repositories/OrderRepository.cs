using System.Net.Http.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RamenGo.Data;
using RamenGo.Domain.DTO;
using RamenGo.Domain.Entities;
using RamenGo.Domain.Interfaces;

namespace RamenGo.Application.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly RamenGoDbContext _ramenGoDbContext;
        private BrothRepository _brothRepository;
        private ProteinRepository _proteinRepository;
        public OrderRepository(RamenGoDbContext ramenGoDbContext){
            _ramenGoDbContext = ramenGoDbContext;        
            _brothRepository = new BrothRepository(ramenGoDbContext);
            _proteinRepository = new ProteinRepository(ramenGoDbContext);
        }
        public async Task<OrderResponse> PlaceOrder(string brothId, string proteinId)
        {
            try
            {
                Broth broth = await _brothRepository.GetByIdAsync(brothId);
                Protein protein = await _proteinRepository.GetByIdAsync(proteinId);
                Dictionary<string, string> responseDictionary;
                string orderId;

                if(broth == null || protein == null)
                    throw new Exception();

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://api.tech.redventures.com.br/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Add("x-api-key", "ZtVdh8XQ2U8pWI2gmZ7f796Vh8GllXoN7mr0djNf");

                    HttpResponseMessage response = await client.PostAsync("orders/generate-id",null);
                    responseDictionary = response.IsSuccessStatusCode? await response.Content.ReadFromJsonAsync<Dictionary<string, string>>() : throw new Exception();
                    orderId = responseDictionary["orderId"];

                }
                OrderResponse orderResponse = new OrderResponse(orderId)
                {
                    Description = $"{broth.Name} and {protein.Name} Ramen",
                    Image = $"https://tech.redventures.com.br/icons/ramen/ramen{protein.Name}.png"
                };

                return orderResponse;
                
            }catch(Exception)
            {
                throw;
            }
        }
    }
}