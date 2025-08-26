using Business.Concrete;
using DataAccess.Concrete.EntityFramework;

//şimdilik new yaptık
//solid
// O -> open closed principle
//yeni bir özellik ekliyorsan mevcuttaki hiçbir koda dokunamazsın
//ınmemoryden entityframeworke geçtik ve hiçbir şey değişmedi

//ProductManager productManager1 = new ProductManager(new EfProductDal());
//foreach (var product in productManager1.GetAll())
//{
//    Console.WriteLine(product.ProductName);
//}

//foreach (var product in productManager1.GetAllByCategoryId(2))
//{
//    Console.WriteLine(product.ProductName);
//}

static void ProductTest()
{
    ProductManager productManager = new ProductManager(new EfProductDal());
    foreach (var product in productManager.GetAllByUnitPrice(40, 100))
    {
        Console.WriteLine(product.ProductName);
    }
}
//ProductTest();

static void CategoryTest()
{
    CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

    foreach (var category in categoryManager.GetAll())
    {
        Console.WriteLine(category.CategoryName);
    }
}
//CategoryTest();

//joini çağırma
static void ProductTest2()
{
    ProductManager productManager2 = new ProductManager(new EfProductDal());
    foreach (var product in productManager2.GetProductDetails())
    {
        Console.WriteLine(product.ProductName+ " / "+ product.CategoryName);
    }
}
//ProductTest2();