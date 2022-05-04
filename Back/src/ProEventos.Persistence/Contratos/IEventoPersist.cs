using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence.Contratos
{
    public interface IEventoPersist
    {
        Task<Evento[]> GetAllEventosByTemaAsysnc(string tema, bool includePalestrantes);
        Task<Evento[]> GetAllEventosAsysnc(bool includePalestrantes);
        Task<Evento> GetEventoByIdAsysnc(int eventoId, bool includePalestrantes);
    }
}