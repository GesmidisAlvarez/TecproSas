using System.Collections.Generic;  
using TecproSas.App.Dominio;
using System.Linq;

namespace TecproSas.App.Persistencia
{
    public class RepositorioCliente : IRepositorioCliente
    {
        private readonly AppContext _appContext;
        public RepositorioCliente(AppContext appContext)
        {
            _appContext=appContext;
        }

        Cliente IRepositorioCliente.AddCliente(Cliente cliente)
        {
            var clienteAdicionado= _appContext.clientes.Add(cliente);
            _appContext.SaveChanges();
            return clienteAdicionado.Entity;
        }
        void IRepositorioCliente.DeleteCliente(int id)
        {
            var clienteEncontrado = _appContext.clientes.FirstOrDefault(c => c.clienteId==id);
            if (clienteEncontrado != null)
            {
                _appContext.clientes.Remove(clienteEncontrado);
                _appContext.SaveChanges();
            }
        }
        IEnumerable<Cliente> IRepositorioCliente.GetALLCliente()
        {
            return _appContext.clientes;
        }
        Cliente IRepositorioCliente.GetCliente (int id)
        {
            return _appContext.clientes.FirstOrDefault(c => c.clienteId == id ); 
        }
        
        Cliente IRepositorioCliente.UpdateCliente(Cliente cliente)
        {
            var clienteEncontrado = _appContext.clientes.FirstOrDefault(c => c.clienteId == cliente.clienteId);
            if (clienteEncontrado!=null)
            {
                clienteEncontrado.nit=cliente.nit;
                clienteEncontrado.nombre=cliente.nombre;
                clienteEncontrado.apellidos=cliente.apellidos;
                clienteEncontrado.telefono=cliente.telefono;
                clienteEncontrado.nacionalidad=cliente.nacionalidad;
                clienteEncontrado.email=cliente.email;
                clienteEncontrado.direccionCliente=cliente.direccionCliente;
      


                _appContext.SaveChanges();
            }
            return clienteEncontrado;
        }
        
        
    }
}