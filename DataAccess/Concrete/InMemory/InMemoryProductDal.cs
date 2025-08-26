using System.Linq.Expressions;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        // global değişkenleri alt çizgi ile ver - commention
        public InMemoryProductDal()
        {
            //veri tabanından geliyormuş gibi simüle ediyoruz
            _products = new List<Product>
            {
                new Product{ProductId=1,CategoryId=1,ProductName="Bardak",UnitPrice=15,UnitsInStock=15},
                new Product{ProductId=2,CategoryId=1,ProductName="Kamera",UnitPrice=500,UnitsInStock=3},
                new Product{ProductId=3,CategoryId=2,ProductName="Telefon",UnitPrice=1500,UnitsInStock=2},
                new Product{ProductId=4,CategoryId=2,ProductName="Klavye",UnitPrice=150,UnitsInStock=65},
                new Product{ProductId=5,CategoryId=2,ProductName="Fare",UnitPrice=85,UnitsInStock=1}
            };
        }
        List<Product> _products;
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //böyle yazarsan silmez çünkü üsttekileri süslü parantez ile tanımladık
            //5 farklı adres açtık yukarda
            //burda açacağımız ise başka bir adresi referans tutar 
            //örneğin 5 ürünün 100 101 102 103 104 olsun
            //bu ise 200ü tutar ve eşleşmez
            //Id kullanarak sil LINQ kullan
            //_products.Remove(product);

            //LINQ kullanmadan
            //kendim farklı bir ürün oluşturdum başta referansı yok new demedim çünkü
            //id ler eşleşirse kendi ürünümün referansı ile listede olanı aynı yaptım
            //böylece kendi ürünümü silince aynı referansta olan listedeki her ürün silinecek
            //Product productToDelete=null;
            //foreach (var p in _products)
            //{
            //    if (product.ProductId==p.ProductId)
            //    {
            //        productToDelete = p;
            //    }
            //}
            //_products.Remove(productToDelete);

            //LINQ ile -- language integrated query -- dile gömülü sorgu
            //ürünleri gezer ve tek bir ürün bulur
            //foreach in işini yapar
            //iki tane gelirse hata verir id bazlı aramalarda kullan
            Product productToDelete = _products.SingleOrDefault(p=>p.ProductId==product.ProductId); 
            //geleni de sileriz
            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public void Update(Product product)
        {
            //gönderdiğim ürün id sine sahip olan listedeki ürünü bul
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            //burda ise güncellemeleri yaptık
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;

        }

        public List<Product> GetAllByCategoryId(int categoryId)
        {
            return _products.Where(p=>p.CategoryId==categoryId).ToList();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }
    }
}
