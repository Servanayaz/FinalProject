using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();
        List<Product> GetAllByCategoryId(int id);
        List<Product> GetAllByUnitPrice(decimal min,decimal max);
        List<ProductDetailDto> GetProductDetails();
        IResult Add(Product product); //eskiden voidken sonuç ve mesaj döndürmek için IResult yaptık
        Product GetById(int productId);
    }
}
