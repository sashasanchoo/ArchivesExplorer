namespace ArchivexExplorer.Domain.Responses
{
    public class ErrorResponse : BaseResponse
    {
        public ErrorResponse()
        {
            IsSuccess = false;
        }

        public string ErrorMessage { get; set; }
    }
}
