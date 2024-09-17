namespace HexagonalAPIWEBWORKER.Core.Domain.Shared
{
    public class MessageError
    {
        public string? Code { get; private set; }
        public string? Description { get; private set; }

        public MessageError(string? errorCode, string? errorDescription)
        {
            Code = errorCode;
            Description = errorDescription;
        }

        public void SetCode(string? errorCode)
        {
            Code = errorCode;
        }

        public void SetDescription(string? errorDescription)
        {
            Description = errorDescription;
        }
    }
}
