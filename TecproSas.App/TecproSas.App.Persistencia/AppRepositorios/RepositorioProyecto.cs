using System.Collections.Generic;  
using TecproSas.App.Dominio;
using System.Linq;


namespace TecproSas.App.Persistencia

{
    public class RepositorioProyecto : IRepositorioProyecto
    {
        private readonly AppContext _appContext;
        public RepositorioProyecto(AppContext appContext)
        {
            _appContext=appContext;
        }

        Proyecto IRepositorioProyecto.AddProyecto(Proyecto proyecto)
        {
            var proyectoAdicionado= _appContext.proyectos.Add(proyecto);
            _appContext.SaveChanges();
            return proyectoAdicionado.Entity; 
        }
        void IRepositorioProyecto.DeleteProyecto(int proyectoId)
        {
            var proyectoEncontrado = _appContext.proyectos.FirstOrDefault(p => p.proyectoId==proyectoId); 
            if (proyectoEncontrado == null)
            return;
            _appContext.proyectos.Remove(proyectoEncontrado);
            _appContext.SaveChanges(); 
        }
        IEnumerable<Proyecto> IRepositorioProyecto.GetALLProyecto()
        {
            return _appContext.proyectos; 
        }
        Proyecto IRepositorioProyecto.GetProyecto (int proyectoId)
        {
            return _appContext.proyectos.FirstOrDefault(p => p.proyectoId == proyectoId); 
        }
        Proyecto IRepositorioProyecto.UpdateProyecto(Proyecto proyecto) 
        {
            var proyectoEncontrado = _appContext.proyectos.FirstOrDefault(p => p.proyectoId == proyecto.proyectoId); 
            if (proyectoEncontrado!=null)
            {
                proyectoEncontrado.clienteId=proyecto.clienteId;
                proyectoEncontrado.servicioId=proyecto.servicioId;
                proyectoEncontrado.faseId =proyecto.faseId ;
                proyectoEncontrado.nombre =proyecto.nombre;
                proyectoEncontrado.aprobadoPor=proyecto.aprobadoPor;
                proyectoEncontrado.descripcion=proyecto.descripcion;
                proyectoEncontrado.fechaInicio=proyecto.fechaInicio;
                proyectoEncontrado.presupuesto=proyecto.presupuesto;
                proyectoEncontrado.tiempoEjecucion=proyecto.tiempoEjecucion;
                proyectoEncontrado.faseActual=proyecto.faseActual;
                
                
                _appContext.SaveChanges();
            }
            return proyectoEncontrado;
        }
        
    }
}