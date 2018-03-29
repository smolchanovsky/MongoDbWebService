namespace Infrastructure.WebApi
{
    /// <summary>
    /// Contains information about error that occurred on web-service.
    /// </summary>
    public class ApiError
    {
        public int Code { get; set; }
        public string Message { get; set; }
    }
}
