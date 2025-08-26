
namespace Core.Utilities.Results
{
    //Temel voidler için
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
    }
}
