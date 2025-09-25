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
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            //IDataResult tipine almadan önce döndürdüğümüz
            //return _productDal.GetAll();
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>> (_productDal.GetAll(p=>p.CategoryId==id));
        }

        public IDataResult<List<Product>> GetAllByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>> (_productDal.GetAll(p =>p.UnitPrice>=min && p.UnitPrice<=max));
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p=>p.ProductId==productId));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>> (_productDal.GetProductDetails());
        }
    }
}
