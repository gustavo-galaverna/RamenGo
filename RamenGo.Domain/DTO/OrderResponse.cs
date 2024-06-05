namespace RamenGo.Domain.DTO
{
    public class OrderResponse
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public OrderResponse(string id)
        {
            this.Id = id;
        }

    }
}