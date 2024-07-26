namespace Para.Base.Response;

public partial class ApiResponse
{
    public string? Message { get; set; }
    public bool IsSuccess { get; set; }
    public DateTime ServerDate { get; set; } = DateTime.UtcNow;
    public Guid ReferenceNumber { get; set; } = Guid.NewGuid();

    public ApiResponse(string? message = null)
    {
        Message = message;
        if (string.IsNullOrEmpty(message))
        {
            IsSuccess = true;
        }
        else
        {
            IsSuccess = false;
            Message = message;
        }
    }
}

public partial class ApiResponse<T>(T data)
{
    public T Data { get; set; } = data;
    public string Message { get; set; } = "Success";
    public bool IsSuccess { get; set; } = true;
    public DateTime ServerDate { get; set; } = DateTime.UtcNow;
    public Guid ReferenceNumber { get; set; } = Guid.NewGuid();
}