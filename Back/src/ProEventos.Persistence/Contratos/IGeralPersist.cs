using System.Threading.Tasks;

namespace ProEventos.Persistence.Contratos
{
    public interface IGeralPersist
    {
         void Add<T>(T entity) where T: class;
         void Update<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         void DeleteRamge<T>(T[] entity) where T: class;
        Task<bool> SaveChenageAsync();
    }
}