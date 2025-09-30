using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]  // attribute
    public class ProductsController : ControllerBase //burdan türetilmeli api olması için
    {
        //loosely coupled -> gevşek bağımlılık
        IProductService _productService;
        //IoC Container -> inversion of control

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public List<Product> Get()
        {
            //bu şeklinde dependency chain -> bağımlılık zinciri var
            //yukarıya IProductService _productService; fieldini ve sonraki consructuru yazdık yazdık kurtarmak için
            //IProductService productService = new ProductManager(new EfProductDal());
            var result = _productService.GetAll();
            return result.Data;
        }
    }
}
