using System.Linq.Expressions;
//eğer böyle verirse entities katmanına bağımlı olurdu başka projelerde kullanamazdın
//biz de IEntityi core taşıyıp kullanmak için burdaki referansı vereceğiz
//core diğer katmanları referans almaz
//using Entities.Abstract;
//using Entities.Concrete;
using Core.Entitites;

//Data access abstracttan buraya taşıdık eski yeri orasıydı
//core katmanını açınca ortak çalışan evrenselleri taşımaya başladık
namespace Core.DataAccess
//namespace DataAccess.Abstract
{
    // generic constraint -  generic kısıt
    //class : referans tip olabilir demek
    //IEntity referansı tutabilmeli IEntity veya onu implemente eden
    //IEntity inteface işimize yaramaz o yüzden new lenebilmeli şartı koyduk ki onu geçemesin T yerine
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        //filtreli de getirebilmeyi sağlar filtre null olabilir nullsa hepsini getirir
        List<T> GetAll(Expression<Func<T,bool>> filter=null);

        //filtreli getirir filtre null olamaz
        T Get(Expression<Func<T, bool>> filter);

        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
