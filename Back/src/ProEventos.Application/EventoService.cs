using System;
using System.Threading.Tasks;
using ProEventos.Application.Contratos;
using ProEventos.Domain;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Application
{
    public class EventoService : IEventoService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IEventoPersist _eventoPersist;
        public EventoService(IGeralPersist geralPersist, IEventoPersist eventoPersist)
        {
            this._eventoPersist = eventoPersist;
            this._geralPersist = geralPersist;
        }
        public async Task<Evento> AddEvento(Evento model)
        {
            try
            {
                _geralPersist.Add<Evento>(model);
                if (await _geralPersist.SaveChenageAsync())
                {
                    return await _eventoPersist.GetEventoByIdAsysnc(model.Id,false);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Evento> UpdateEvento(int eventoId, Evento model)
        {
            try
            {
                var evento = await _eventoPersist.GetEventoByIdAsysnc(eventoId, false);
                if (evento == null) return null;

                model.Id = eventoId;

                _geralPersist.Update(model);
                if (await _geralPersist.SaveChenageAsync())
                {
                    return await _eventoPersist.GetEventoByIdAsysnc(model.Id,false);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeleteEvento(int eventoId)
        {
            try
            {
                var evento = await _eventoPersist.GetEventoByIdAsysnc(eventoId, false);
                if (evento == null) throw new Exception("Evento para o delete não encontrado.");

                _geralPersist.Delete<Evento>(evento);
                return await _geralPersist.SaveChenageAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Evento[]> GetAllEventosAsysnc(bool includePalestrantes = false)
        {
            try
            {
                 var eventos = await _eventoPersist.GetAllEventosAsysnc(includePalestrantes);
                 if (eventos == null) return null;

                 return eventos;
            }
            catch (Exception ex)
            {
                {
                    throw new Exception(ex.Message);   
                }
            }
        }
        public async Task<Evento[]> GetAllEventosByTemaAsysnc(string tema, bool includePalestrantes = false)
        {
            try
            {
                 var eventos = await _eventoPersist.GetAllEventosByTemaAsysnc(tema, includePalestrantes);
                 if (eventos == null) return null;

                 return eventos;
            }
            catch (Exception ex)
            {
                {
                    throw new Exception(ex.Message);   
                }
            }
        }
        public async Task<Evento> GetEventoByIdAsysnc(int eventoId, bool includePalestrantes = false)
        {
            try
            {
                 var eventos = await _eventoPersist.GetEventoByIdAsysnc(eventoId, includePalestrantes);
                 if (eventos == null) return null;

                 return eventos;
            }
            catch (Exception ex)
            {
                {
                    throw new Exception(ex.Message);   
                }
            }
        }
    }
}