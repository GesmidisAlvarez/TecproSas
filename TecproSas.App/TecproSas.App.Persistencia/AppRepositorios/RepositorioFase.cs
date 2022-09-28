using System.Collections.Generic;  
using TecproSas.App.Dominio;
using System.Linq;

namespace TecproSas.App.Persistencia

{
    public class RepositorioFase : IRepositorioFase
    {
        private readonly AppContext _appContext;
        public RepositorioFase(AppContext appContext)
        {
            _appContext=appContext;
        }

        Fase IRepositorioFase.AddFase(Fase fase)
        {
            var faseAdicionado= _appContext.fases.Add(fase);
            _appContext.SaveChanges();
            return faseAdicionado.Entity; 
        }
        void IRepositorioFase.DeleteFase(int id)
        {
            var faseEncontrado = _appContext.fases.FirstOrDefault(f => f.faseId==id); 
            if (faseEncontrado == null)
            return;
            _appContext.fases.Remove(faseEncontrado);
            _appContext.SaveChanges(); 
        }
        IEnumerable<Fase> IRepositorioFase.GetALLFase()
        {
            return _appContext.fases; 
        }
        Fase IRepositorioFase.GetFase (int faseId)
        {
            return _appContext.fases.FirstOrDefault(f => f.faseId == faseId);
        } 
        
        Fase IRepositorioFase.UpdateFase(Fase fase) 
        {
            var faseEncontrado = _appContext.fases.FirstOrDefault(f => f.faseId == fase.faseId); 
            if (faseEncontrado!=null)
            {
                faseEncontrado.nombreFase=fase.nombreFase;
                faseEncontrado.fechaInicioFase=fase.fechaInicioFase;
                faseEncontrado.visitas=fase.visitas;
                faseEncontrado.fechaVisitas =fase.fechaVisitas ; 
                faseEncontrado.actualizacionVisita=fase.actualizacionVisita;
               

                _appContext.SaveChanges();
            }
            return faseEncontrado;
        }
    }
}
    