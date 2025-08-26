using Core.Entitites;

namespace Entities.DTOs
{
    //DTO -> data transformation object -> joinlerle getireceğimiz ortak tablolar vs için
    public class ProductDetailDto : IDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public short UnitsInStock { get; set; }
    }
}
