namespace RamenGo.Domain.DTO
{
    public class ErrorResponse
    {
        public string Error { get; set; }

        public ErrorResponse(string error)
        {
            this.Error = error;
        }

    }
}