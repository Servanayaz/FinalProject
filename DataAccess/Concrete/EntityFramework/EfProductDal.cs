using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    // ORM -> amaç veri tabanındaki tabloyu classmış gibi ilişkilendirip bütün SQL leri LINQ ile yaptığımız ortam
    //    ORM, Object Relational Mapping(Nesne-İlişkisel Eşleme) kavramının kısaltmasıdır.
    //Basitçe anlatmak gerekirse:
    //Programlama dillerinde verilerle nesneler (class, object) üzerinden çalışırız.
    //Veritabanlarında ise veriler tablolar, satırlar ve sütunlar halinde tutulur.
    //ORM, bu iki farklı dünyayı köprüleyen bir tekniktir.Yani veritabanındaki tabloları programlama dilindeki sınıflara eşler, satırları ise nesnelere dönüştürür.
    //Avantajları:
    //SQL sorgularını elle yazmak yerine kod ile nesneler üzerinden veritabanı işlemleri yapılabilir.
    //Daha okunabilir ve bakımı kolay bir yapı sağlar.
    //Farklı veritabanlarına geçişi kolaylaştırır (örn: MySQL’den PostgreSQL’e).
    //Güvenlik avantajı sunar(SQL injection riskini azaltır).
    public class EfProductDal : EfEntityRepositoryBase<Product, NortwindContext>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetails()
        {
            using(NortwindContext context = new NortwindContext())
            {
                //ürünlerle categorileri joinle
                var result= from p in context.Products
                            join c in context.Categories
                            on p.CategoryId equals c.CategoryId
                            select new ProductDetailDto 
                            {
                                ProductId=p.ProductId,ProductName=p.ProductName,
                                CategoryName=c.CategoryName,UnitsInStock=p.UnitsInStock
                            };
                return result.ToList();
            }
        }
    }
}
