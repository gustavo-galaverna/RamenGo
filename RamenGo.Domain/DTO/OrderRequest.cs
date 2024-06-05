namespace RamenGo.Domain.DTO
{
    public class OrderRequest
    {
        public string BrothId { get; set; }
        public string ProteinId { get; set; }

        public OrderRequest(string brothId, string proteinId)
        {
            BrothId = brothId;
            ProteinId = proteinId;
        }
    }
}