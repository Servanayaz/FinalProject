using Core.Entitites;

namespace Entities.Concrete
{
    public class Category : IEntity
    {
        //çıplak class kalmasın
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
