using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal; 
        }

        public IResult Add(Product product)
        {
            //else yazmaya gerek yok çünkü if çalışırsa zaten return olacak
            if (product.ProductName.Length<2)
            {
                //returnden sonra yazdığımız -> "Ürün ismi en az 2 karakter olmalıdır!" şundan kurtulalım
                //businesse constans -> proje sabitlerini atmak için klasörü oluştur oraya at ordan çağır
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            //iş kodları
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult<List<Product>> GetAll()
        {
            //iş kodları  -> yetkisi var mı vs
            //geçtiyse iş kodlarından data accesse gider
            //iş sınıfı başka sınıfı newlemez

            //Saat 22 ise 23e kadar listelenmeyi durdur değilse başarılı listele
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult();
            }
            //IDataResult tipine almadan önce döndürdüğümüz
            //return _productDal.GetAll();
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),true,Messages.ProductList);
        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _productDal.GetAll(p=>p.CategoryId==id);
        }

        public List<Product> GetAllByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p =>p.UnitPrice>=min && p.UnitPrice<=max);
        }

        public Product GetById(int productId)
        {
            return _productDal.Get(p=>p.ProductId==productId);
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            return _productDal.GetProductDetails();
        }
    }
}
