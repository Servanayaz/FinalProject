
using System.Linq.Expressions;
using Core.Entitites;
using Microsoft.EntityFrameworkCore;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            //IDispossable pattern implementation of c#
            //using içine yazınca kullanım bittiği anda bellekten atar
            using (TContext context = new TContext())
            {
                //ekleme kodları
                //addedEntityye contextte metotla göndereceğimizin referansını ver sonra
                var addedEntity = context.Entry(entity);

                //entityFramework ün sağladığı kolaylıkla ekle
                //nesnenin durumunu entitydurumlarından ekleme durumuna eşleyerek
                addedEntity.State = EntityState.Added;

                //değişiklikleri kaydet
                context.SaveChanges();

                //özet olarak
                //referansı yakala
                //bu eklenecek bir nesne
                //değişiklikleri kaydet
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                //tek bilgi getirir
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                //filtre null mı?
                //nullsa ilk kısım değilse ikinci kısım çalışır
                //ilk kısım (toliste kadar) producta yerleş ve ordaki tüm datayı listeye çevir -> select * from product
                //ikinci kısım filtreye göre getir
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }
        }
    }
}
