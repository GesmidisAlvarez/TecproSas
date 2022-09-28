using System.Collections.Generic;  
using TecproSas.App.Dominio;
using System.Linq;


namespace TecproSas.App.Persistencia

{
    public class RepositorioServicio : IRepositorioServicio
    {
        private readonly AppContext _appContext;
        public RepositorioServicio(AppContext appContext)
        {
            _appContext=appContext;
        }

        Servicio IRepositorioServicio.AddServicio(Servicio Servicio)
        {
            var servicioAdicionado= _appContext.servicios.Add(Servicio);
            _appContext.SaveChanges();
            return servicioAdicionado.Entity; 
        }
        void IRepositorioServicio.DeleteServicio(int servicioId)
        {
            var servicioEncontrado = _appContext.servicios.FirstOrDefault(s => s.servicioId==servicioId); 
            if (servicioEncontrado == null)
            return;
            _appContext.servicios.Remove(servicioEncontrado);
            _appContext.SaveChanges(); 
        }
        IEnumerable<Servicio> IRepositorioServicio.GetALLServicio()
        {
            return _appContext.servicios; 
        }
        Servicio IRepositorioServicio.GetServicio (int servicioId)
        {
            return _appContext.servicios.FirstOrDefault(s => s.servicioId == servicioId); 
        }
        Servicio IRepositorioServicio.UpdateServicio(Servicio Servicio) 
        {
            var servicioEncontrado = _appContext.servicios.FirstOrDefault(s => s.servicioId == Servicio.servicioId); 
            if (servicioEncontrado!=null)
            {
                servicioEncontrado.nombServicio=Servicio.nombServicio;
                servicioEncontrado.valor=Servicio.valor;
                servicioEncontrado.fechaInicio=Servicio.fechaInicio;
                servicioEncontrado.descripcion=Servicio.descripcion;
                
                
                _appContext.SaveChanges();
            }
            return servicioEncontrado;
        }
        
    }
}