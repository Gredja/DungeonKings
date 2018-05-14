namespace DungeonKings.ErrorModel
{
    public class ErrorBody
    {
        public string Code { get; }
        public string Message { get; }

        public ErrorBody(string code, string message)
        {
            Code = code;
            Message = message;
        }
    }
}