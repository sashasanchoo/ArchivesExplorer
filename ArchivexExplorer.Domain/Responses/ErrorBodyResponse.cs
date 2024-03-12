namespace ArchivexExplorer.Domain.Responses
{
    public class ErrorBodyResponse<T> : ErrorResponse
    {
        public ErrorBodyResponse(T body)
        {
            Body = body;
            IsSuccess = false;
        }

        public T Body { get; set; }
    }
}
