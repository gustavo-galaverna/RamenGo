public class ApiKeyValidator : IApiKeyValidator
{
    public bool IsValid(string apiKey)
    {
        return apiKey == "ZtVdh8XQ2U8pWI2gmZ7f796Vh8GllXoN7mr0djNf";
    }
}

public interface IApiKeyValidator
{
    bool IsValid(string apiKey);
}