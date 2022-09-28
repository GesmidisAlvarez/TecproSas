using System.Collections.Generic;  
using TecproSas.App.Dominio;

namespace TecproSas.App.Persistencia
{

    public interface IRepositorioServicio
    {
        IEnumerable <Servicio> GetALLServicio();  
        Servicio AddServicio(Servicio servicio);
        Servicio UpdateServicio(Servicio servicio);
        void DeleteServicio(int servicioId);
        Servicio GetServicio(int servicioId);
    }
    
}