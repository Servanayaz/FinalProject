using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    //Dal -> Data Access Layer den gelir
    public interface IProductDal : IEntityRepository<Product>
    {
        //producta özel metot joinler için mesela
        //şimdi onu EfProductDalda implement edeceğiz
        List<ProductDetailDto> GetProductDetails();
    }
}
