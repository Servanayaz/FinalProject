using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IProductService
    {
        //List<Product> GetAll(); eski hali böyleydi işlem sonucu ve mesajı da göndermek istedik diye böyle yaptık
        IDataResult<List<Product>> GetAll();
        IDataResult<List<Product>> GetAllByCategoryId(int id);
        IDataResult<List<Product>> GetAllByUnitPrice(decimal min,decimal max);
        IDataResult<List<ProductDetailDto>> GetProductDetails();
        IResult Add(Product product); //eskiden voidken sonuç ve mesaj döndürmek için IResult yaptık
        
        //Product GetById(int productId); Bu da böyle iken
        IDataResult<Product> GetById(int productId);
    }
}
