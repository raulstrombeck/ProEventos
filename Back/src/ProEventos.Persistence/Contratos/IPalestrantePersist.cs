using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence.Contratos
{
    public interface IPalestrantePersist
    {
        Task<Palestrante[]> GetAllPalestrantesByNomeAsysnc(string nome, bool includeEventos);
        Task<Palestrante[]> GetAllPalestrantesAsysnc(bool includeEventos);
        Task<Palestrante> GetPalestranteByIdAsysnc(int palestranteId, bool includeEventos);
    }
}