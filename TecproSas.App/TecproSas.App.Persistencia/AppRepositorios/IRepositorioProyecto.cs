using System.Collections.Generic;  
using TecproSas.App.Dominio;

namespace TecproSas.App.Persistencia
{

    public interface IRepositorioProyecto
    {
        IEnumerable <Proyecto> GetALLProyecto();  
        Proyecto AddProyecto(Proyecto proyecto);
        Proyecto UpdateProyecto(Proyecto proyecto);
        void DeleteProyecto(int proyectoId);
        Proyecto GetProyecto(int proyectoId);
    }
    
}