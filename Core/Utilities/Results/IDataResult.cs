
namespace Core.Utilities.Results
{
    public interface IDataResult<T> : IResult //mesaj ve sonuç bilgisini bir daha yazma diye türettik kısıt koymadı T her şey olabilir
                                              //veri döndürmeyi de burda yapacağız
    {
        T Data { get; }
    }
}
