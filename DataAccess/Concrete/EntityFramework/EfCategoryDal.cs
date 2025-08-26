using System.Linq.Expressions;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    //ICategoyDal da duracak çünkü sınıfa özgü metotlar olacak onları buraya atacağız.
    //ilk imlementasyon entitiyframework için yarın nhibernate geçersek orası değişir sadece
    public class EfCategoryDal : EfEntityRepositoryBase<Category, NortwindContext>, ICategoryDal
    {
    }
}
