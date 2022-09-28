using System.Collections.Generic;  
using TecproSas.App.Dominio;

namespace TecproSas.App.Persistencia
{

    public interface IRepositorioCliente
    {

        Cliente AddCliente(Cliente clientnuevo);
        Cliente UpdateCliente(Cliente clientenuevo);
        void DeleteCliente(int clienteId);
        Cliente GetCliente(int clienteId);
        IEnumerable <Cliente> GetALLCliente(); 
        
        

    }
    
}