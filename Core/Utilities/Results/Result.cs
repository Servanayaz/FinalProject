
namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        //sadece get olan fieldlar consructurda set edilebilir 
        public bool Success { get; }
        public string Message { get; }

        public Result(bool success)
        {
            Success = success;
        }
        //overload ettik
        public Result(bool success, string message ):this( success ) //iki parametreli yollarsan üstteki de çalışır otomatik olarak
        {
            Message = message;
        }
    }
}
