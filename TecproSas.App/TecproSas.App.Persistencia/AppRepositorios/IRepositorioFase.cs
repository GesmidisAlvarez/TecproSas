using System.Collections.Generic;  
using TecproSas.App.Dominio;

namespace TecproSas.App.Persistencia
{

    public interface IRepositorioFase
    {
        IEnumerable <Fase> GetALLFase();  
        Fase AddFase (Fase fase);
        Fase UpdateFase(Fase fase);
        void DeleteFase(int faseId);
        Fase GetFase(int faseId);
    }
    
}