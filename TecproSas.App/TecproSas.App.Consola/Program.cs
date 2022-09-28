using System;
using TecproSas.App.Dominio;
using TecproSas.App.Persistencia;


namespace TecproSas.App.Consola
{
    class Program
    {
        private static IRepositorioCliente _repoCliente = new RepositorioCliente(new TecproSas.App.Persistencia.AppContext());
        private static IRepositorioProyecto _repoProyecto = new RepositorioProyecto(new TecproSas.App.Persistencia.AppContext());
        private static IRepositorioLogin _repoLogin = new RepositorioLogin(new TecproSas.App.Persistencia.AppContext());
       //repositorio Usuario
        private static IRepositorioUsuario _repousuario = new RepositorioUsuario(new TecproSas.App.Persistencia.AppContext());
        //repositorio Servicio
        private static IRepositorioServicio _repoServicio = new RepositorioServicio(new TecproSas.App.Persistencia.AppContext());
        //repositorio Fase
        private static IRepositorioFase _repoFase = new RepositorioFase(new TecproSas.App.Persistencia.AppContext());
        
        static void Main(string[] args)
        {
            Console.WriteLine("Tecprodes Sas APP!");

            //Funciones de Cliente    
            Console.WriteLine("CLIENTES!");
            AgregarCliente();
            ModificarCliente();
            BorrarCliente();
            BuscarCliente(); 
            ObtenerClientes(); 

            //Funciones proyecto
            Console.WriteLine("PROYECTO!");
            AgregarProyecto();
            ModificarProyecto();
            BuscarProyecto();
            ObtenerProyetos(); 
            BorrarProyecto();

            //Funciones Login
            Console.WriteLine("LOGIN!");
            AgregarLogin();
            ModificarLogin();
            BuscarLogin();
            ObtenerLogins();
            BorrarLogin();

            //Funciones de Usuario
            Console.WriteLine("USUARIOS!");
            AgregarUsuario();
            ModificarUsuario();
            BorrarUsuario();
            BuscarUsuario(); 
            ObtenerUsuarios(); 
            
            //Funciones de Servicio        
			Console.WriteLine("SERVICIOS!");
            AgregarServicio();
            ModificarServicio();
            BorrarServicio();
            BuscarServicio(); 
            ObtenerServicios(); 

           //Método Fases
            Console.WriteLine("FASES!");
            AgregarFase();
            ModificarFase();
            BorrarFase();
            BuscarFase(); 
            ObtenerFases();  

        }

        //*********************************************************************
        //Metodo de Fase

        private static void AgregarFase()
        {
            //Instanciar la entidad 
            Fase fase = new Fase();

            Console.WriteLine("Escriba el nombre de la fase:");
            fase.nombreFase = Console.ReadLine();

            Console.WriteLine("Escriba la Fecha Inicio Fase:"); 
            fase.fechaInicioFase = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Escriba detalles de la visita realizada:");
            fase.visitas = Console.ReadLine();
            
            Console.WriteLine("Fecha de la Visita:"); 
            fase.fechaVisitas = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Escriba las actualizaciones de la visita:");
            fase.actualizacionVisita = Console.ReadLine();
            

            //Invocamos al Repositorio
            _repoFase.AddFase(fase);

        }
        public static void ModificarFase()
        {            
            Console.WriteLine("Ingrese el id de la fase a modificar:");
            int id = int.Parse(Console.ReadLine());
            Fase fase = _repoFase.GetFase(id);

            // Pedir los nuevos datos
            Console.WriteLine("Escriba el nuevo nombre de la fase:");
            fase.nombreFase = Console.ReadLine();

            Console.WriteLine("Escriba la Fecha Inicio Fase:"); 
            fase.fechaInicioFase = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Escriba  los nuevos detalles de la visita realizada:");
            fase.visitas = Console.ReadLine();
            
            Console.WriteLine("Escriba la nueva Fecha de la Visita:"); 
            fase.fechaVisitas = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Escriba las nuevas actualizaciones de la visita:");
            fase.actualizacionVisita = Console.ReadLine();

            _repoFase.UpdateFase(fase);
            
        }
        private static void BuscarFase()
        {  
            // pedir el id del fase a buscar 
            Console.WriteLine("Ingrese el id de la fase a buscar:");
            int id = int.Parse(Console.ReadLine());
            Fase fase = _repoFase.GetFase(id);
            // buscar el Fase
            Console.WriteLine("Fase: " + fase.nombreFase + " " + fase.fechaInicioFase + " " + fase.visitas + " " + fase.fechaVisitas + " " +  fase.actualizacionVisita + "" );
        }

         private static void ObtenerFases()
        {
            // Traer todos las fases registradas (lista)
            var fases = _repoFase.GetALLFase();
            // Recorrer y mostrar las fases
            foreach (var fase in fases)
        { 
            Console.WriteLine("Fase: " + fase.nombreFase + " " + fase.fechaInicioFase + " " + fase.visitas + " " + fase.fechaVisitas + " " +  fase.actualizacionVisita + "" );
        } 
        }
    
         private static void BorrarFase()
        {
            // Pedir el id de la fase a borrar 
            Console.WriteLine("Ingrese el id de la Fase a borrar"); 
            int id = int.Parse(Console.ReadLine());
            _repoFase.DeleteFase(id);
        }

        //**************************************************************************************
        //Métodos de Login

        private static void AgregarLogin()
        {
            //Instanciar la entidad 
            Login login = new Login();

            Console.WriteLine("Fecha Registro:"); 
            login.fechaRegistro = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Direccion Ip:"); 
            login.direccionIp = Console.ReadLine();

            // Asignamos las relaciones 
            Console.WriteLine("Ingrese Id del Usuario:");
            login.usuarioId = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese Id del servicio:");
            login.clienteId = int.Parse(Console.ReadLine());
            

            //Invocamos al Repositorio
            _repoLogin.AddLogin(login);

        }
        public static void ModificarLogin()
        {            
            Console.WriteLine("Ingrese el id del login a modificar:");
            int id = int.Parse(Console.ReadLine());
            Login login = _repoLogin.GetLogin(id);

            // Pedir los nuevos datos

           Console.WriteLine("Fecha Registro:"); 
            login.fechaRegistro = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Direccion Ip:"); 
            login.direccionIp = Console.ReadLine();

            _repoLogin.UpdateLogin(login);
            
        }
        private static void BuscarLogin()
        {  
            // pedir el id del login a buscar 
            Console.WriteLine("Ingrese el id del login a buscar:");
            int id = int.Parse(Console.ReadLine());
            Login login = _repoLogin.GetLogin(id);
            // buscar el login
            Console.WriteLine("Login: " + login.fechaRegistro + " " + login.direccionIp + " " );
        }

         private static void ObtenerLogins()
        {
            // Traer todos los login (lista)
            var logins = _repoLogin.GetALLLogin();
            // Recorrer y mostrar los login
            foreach (var login in logins)
        { 
            Console.WriteLine("Login: " + login.fechaRegistro + " " + login.direccionIp + " " );
        } 
        }
    
         private static void BorrarLogin()
        {
            // Pedir el id dellogin a borrar 
            Console.WriteLine("Ingrese el id del Login a borrar"); 
            int id = int.Parse(Console.ReadLine());
            _repoLogin.DeleteLogin(id);
        }

        //********************************************************************************
        //Métodos de Servicio
        
        // Borrar Servicio
        private static void BorrarServicio()
        {
        // Pedir el id del Servicios a borrar 
        Console.WriteLine("Ingrese el id del Servicio a borrar"); 
        int id = int.Parse(Console.ReadLine());
        _repoServicio.DeleteServicio(id);
        }
		
        
        // Obtener Servicio
        private static void ObtenerServicios()
        {
            // Traer todos los Servicio (lista)
            var servicios = _repoServicio.GetALLServicio();
             // Recorrer y mostrar los Servicios
             foreach (var servicio in servicios)
            {
                
				Console.WriteLine("El Servicio es: " + servicio.nombServicio + " " + servicio.valor + " " + servicio.fechaInicio + " " + servicio.descripcion + " ");
				
            } 
        }
       
       
        // Buscar Servicio
        private static void BuscarServicio()
        {  
             // pedir el id del Servicio a buscar 
            Console.WriteLine("Ingrese el id del Servicio a buscar"); 
            int id = int.Parse(Console.ReadLine());
            // buscar el Servicio
            Servicio servicio = _repoServicio.GetServicio(id); 
           Console.WriteLine("El Servicio es: " + servicio.nombServicio + " " + servicio.valor + " " + servicio.fechaInicio + " " + servicio.descripcion + " ");
				
        }


        // Modificar Servicio
        public static void ModificarServicio()
        {

            // Pedir el id del Servicios a modificar 
            Console.WriteLine("Ingrese el id del Servicio a modificar:");
            int id = int.Parse(Console.ReadLine());

            Servicio servicio = _repoServicio.GetServicio(id);

            // Pedir los nuevos datos

            Console.WriteLine("Escriba el nuevo nombre del Servicio:");
			servicio.nombServicio = Console.ReadLine();

            //ojo Parse int 
            Console.WriteLine("Escriba el nuevo valor del Servicio:");
			servicio.valor = int.Parse(Console.ReadLine());
            

            //ojo Datetime
	        Console.WriteLine("Escriba la nueva Fecha de inicio del Servicio (aaaa/mm/dd) : ");
			servicio.fechaInicio = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Escriba la nueva descripcion del Servicio:");
			servicio.descripcion = Console.ReadLine();
			
            _repoServicio.UpdateServicio(servicio);
        }

        // Agregar Servicio
        public static void AgregarServicio()
        {
            Console.WriteLine("Agregar un Servicio");
            
			//Instanciar la entidad 
            Servicio servicioNuevo = new Servicio();


            // Obtener los datos del Servicios
			
			Console.WriteLine("Escriba el nombre del Servicio:");
			servicioNuevo.nombServicio = Console.ReadLine();

            //recibir un int
            Console.WriteLine("Escriba el valor del Servicio:");
			servicioNuevo.valor =int.Parse(Console.ReadLine());
            

            //recibir un Date
			Console.WriteLine("Escriba la Fecha de inicio del Servicio (aaaa/mm/dd) : ");
			servicioNuevo.fechaInicio = DateTime.Parse (Console.ReadLine());


            Console.WriteLine("Escriba la descripcion del Servicio:");
			servicioNuevo.descripcion = Console.ReadLine();
			

            
            //Invocamos al Repositorio
            _repoServicio.AddServicio(servicioNuevo);
        }


        //***********************************************************************
        //Métodos de Usuario

        // Borrar Usuario
        private static void BorrarUsuario()
        {
        // Pedir el id del usuario a borrar 
        Console.WriteLine("Ingrese el id del usuario a borrar"); 
        int id = int.Parse(Console.ReadLine());
        _repousuario.DeleteUsuario(id);
        }
		
        // Obtener Usuario		
        private static void ObtenerUsuarios()
        {
            // Traer todos los usuarios (lista)
            var usuarios = _repousuario.GetALLUsuario();
             
             
             // Recorrer y mostrar los usuarios
            foreach (var usuario in usuarios)
            {
				Console.WriteLine("El usuario es: " + usuario.nombre + " " + usuario.apellidos + " "+ usuario.direccion + " " + usuario.rol + " " + usuario.estado + " " + usuario.nicknname + " " + usuario.contrasenia + " " );
            
			} 
        }
        
        
        
        // Buscar Usuario
        private static void BuscarUsuario()
        {  
             // pedir el id del usuario a buscar 
            Console.WriteLine("Ingrese el id del usuario a buscar"); 
            int id = int.Parse(Console.ReadLine());
            // buscar el usuario
            Usuario usuario = _repousuario.GetUsuario(id); 
			Console.WriteLine("El usuario es: " + usuario.nombre + " " + usuario.direccion + " " + usuario.rol + " " + usuario.estado + " " + usuario.nicknname + " " + usuario.contrasenia + " " );
        }
		
        // Modificar Usuario		
        public static void ModificarUsuario()
        {

            // Pedir el id del usuario a modificar 
            Console.WriteLine("Ingrese el id del usuario a modificar:");
            int id = int.Parse(Console.ReadLine());

            Usuario usuario = _repousuario.GetUsuario(id);

            // Pedir los nuevos datos

            Console.WriteLine("Escriba el nuevo  nombre del usuario:");
            usuario.nombre = Console.ReadLine();

            Console.WriteLine("Escriba los nuevos  apellidos del usuario:"); 
            usuario.apellidos = Console.ReadLine();
			
			Console.WriteLine("Escriba la nueva direccion del usuario:"); 
            usuario.direccion = Console.ReadLine();

            // OJO este es un enum
            Console.WriteLine("Escriba el nuevo rol del usuario (0 - Empleado, 1 - Administrador, 2 - Cliente) :"); 
            usuario.rol=(Rol)Enum.Parse(typeof(Rol), Console.ReadLine());
            
            Console.WriteLine("Escriba el nuevo nombre de usuario:"); 
            usuario.nicknname = Console.ReadLine();

            Console.WriteLine("Escriba la nueva contrasenia del usuario:"); 
            usuario.contrasenia = Console.ReadLine();


            _repousuario.UpdateUsuario(usuario);
        }
        
        
        // Agregar Usuario
        public static void AgregarUsuario()
        {
            Console.WriteLine("Agregar un usuario");
            //Instanciar la entidad 
            Usuario usuarioNuevo = new Usuario();

            // Obtener los datos del usuario


            Console.WriteLine("Escriba el nombre del usuario:");
            usuarioNuevo.nombre = Console.ReadLine();

            Console.WriteLine("Escriba los apellidos del usuario:"); 
            usuarioNuevo.apellidos = Console.ReadLine();
			
			Console.WriteLine("Escriba la direccion del usuario:"); 
            usuarioNuevo.direccion = Console.ReadLine();

            // OJO este es un enum
            Console.WriteLine("Escriba el nuevo  rol del usuario (0 - Empleado, 1 - Administrador, 2 - Cliente) :"); 
            usuarioNuevo.rol=(Rol)Enum.Parse(typeof(Rol), Console.ReadLine());

            Console.WriteLine("Escriba el nombre de usuario:"); 
            usuarioNuevo.nicknname = Console.ReadLine();

            Console.WriteLine("Escriba la contrasenia del usuario:"); 
            usuarioNuevo.contrasenia = Console.ReadLine();
            
            //Invocamos al Repositorio
            _repousuario.AddUsuario(usuarioNuevo);
        }

        //***********************
        //Métodos de Proyecto 

        private static void AgregarProyecto()
        {
            //Instanciar la entidad 
            Proyecto proyecto = new Proyecto();

            //Pedir al Usuario datos del proyecto
            Console.WriteLine("Escriba el nombre del proyecto:");
            proyecto.nombre = Console.ReadLine();

            Console.WriteLine("Este proyecto lo aprueba:");
            proyecto.aprobadoPor  = Console.ReadLine();

            Console.WriteLine("Agregue una descripcion sobre el proyecto:"); 
            proyecto.descripcion = Console.ReadLine();

            Console.WriteLine("Ingrese la fecha de Inicio del Proyecto:"); 
            proyecto.fechaInicio = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Digite el Presupuesto del Proyecto:"); 
            proyecto.presupuesto = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese Tiempo de Ejecucion del Proyecto:"); 
            proyecto.tiempoEjecucion = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Escriba Fase del Proyecto presione:(1 Inicial, 2 Intermedio, 3 Final)");
            proyecto.faseActual = int.Parse(Console.ReadLine());

            // Asignamos las relaciones 
            Console.WriteLine("Ingrese Id del cliente:");
            proyecto.clienteId = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese Id del servicio:");
            proyecto.servicioId = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese Id de la fase del proyecto:");
            proyecto.faseId = int.Parse(Console.ReadLine());

            //Invocamos al Repositorio
            _repoProyecto.AddProyecto(proyecto);

        }
   
        public static void ModificarProyecto()
        {

            // Pedir el id del cliente a modificar 
            Console.WriteLine("Ingrese el id del proyecto a modificar:");
            int id = int.Parse(Console.ReadLine());
            Proyecto proyecto = _repoProyecto.GetProyecto(id);

            // Pedir los nuevos datos

            Console.WriteLine("Escriba el nombre del proyecto:");
            proyecto.nombre = Console.ReadLine();

            Console.WriteLine("Este proyecto lo aprueba:");
            proyecto.aprobadoPor  = Console.ReadLine();

            Console.WriteLine("Agregue una descripcion sobre el proyecto:"); 
            proyecto.descripcion = Console.ReadLine();

            Console.WriteLine("Ingrese la fecha de Inicio del Proyecto:"); 
            proyecto.fechaInicio = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Digite el Presupuesto del Proyecto:"); 
            proyecto.presupuesto = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese Tiempo de Ejecucion del Proyecto:"); 
            proyecto.tiempoEjecucion = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Escriba Fase del Proyecto presione:(1 Inicial, 2 Intermedio, 3 Final)");
            proyecto.faseActual = int.Parse(Console.ReadLine());

            _repoProyecto.UpdateProyecto(proyecto);
        }

        private static void BuscarProyecto()
        {  
            // pedir el id del proyecto a buscar 
            Console.WriteLine("Ingrese el id del proyecto a buscar:");
            int id = int.Parse(Console.ReadLine());
            Proyecto proyecto = _repoProyecto.GetProyecto(id);
            // buscar el proyecto
            Console.WriteLine("Proyecto: " + proyecto.nombre + " " + proyecto.aprobadoPor + " " + proyecto.descripcion + " " + proyecto.fechaInicio + " " + proyecto.presupuesto + " " +  proyecto.tiempoEjecucion + " " + proyecto.faseActual + " " );
        }

        private static void ObtenerProyetos()
        {
            // Traer todos los proyectos (lista)
            var proyectos = _repoProyecto.GetALLProyecto();
            // Recorrer y mostrar los proyectos
            foreach (var proyecto in proyectos)
        { 
            Console.WriteLine("Proyecto: " + proyecto.nombre + " " + proyecto.aprobadoPor + " " + proyecto.descripcion + " " + proyecto.fechaInicio + " " + proyecto.presupuesto + " " +  proyecto.tiempoEjecucion + " " + proyecto.faseActual + " " );
        } 
        }

        private static void BorrarProyecto()
        {
            // Pedir el id del proyecto a borrar 
            Console.WriteLine("Ingrese el id del proyecto a borrar"); 
            int id = int.Parse(Console.ReadLine());
            _repoProyecto.DeleteProyecto(id);
        }
       
        //******************************
		//Métodos de Cliente   


        private static void BorrarCliente()
        {
            // Pedir el id del cliente a borrar 
            Console.WriteLine("Ingrese el id del cliente a borrar"); 
            int id = int.Parse(Console.ReadLine());
            _repoCliente.DeleteCliente(id);
        }

        private static void ObtenerClientes()
        {
            // Traer todos los clientes (lista)
            var clientes = _repoCliente.GetALLCliente();
             // Recorrer y mostrar los clientes 
             foreach (var cliente in clientes)
            {
                Console.WriteLine("El cliente es: " + cliente.nit + " " + cliente.nombre + " " + cliente.apellidos + " " + cliente.telefono + " " + cliente.nacionalidad + " " + cliente.email + " " + cliente.direccionCliente + " " );
            } 
        }

        private static void BuscarCliente()
        {  
             // pedir el id del cliente a buscar 
            Console.WriteLine("Ingrese el id del cliente a buscar"); 
            int id = int.Parse(Console.ReadLine());
            // buscar el cliente
            Cliente cliente = _repoCliente.GetCliente(id); 
            Console.WriteLine("El cliente es: " + cliente.nit + " " + cliente.nombre + " " + cliente.apellidos + " " + cliente.telefono + " " + cliente.nacionalidad + " " + cliente.email + " " + cliente.direccionCliente + " " );
        }
        public static void ModificarCliente()
        {

            // Pedir el id del cliente a modificar 
            Console.WriteLine("Ingrese el id del cliente a modificar:");
            int id = int.Parse(Console.ReadLine());
            Cliente cliente = _repoCliente.GetCliente(id);

            // Pedir los nuevos datos

             Console.WriteLine("Escriba el nuevo nit del cliente:");
            cliente.nit = Console.ReadLine();

            Console.WriteLine("Escriba el nuevo  nombre del cliente:");
            cliente.nombre = Console.ReadLine();

            Console.WriteLine("Escriba el nuevo  apellido del cliente:"); 
            cliente.apellidos = Console.ReadLine();

            Console.WriteLine("Escriba el nuevo  telefono del cliente:"); 
            cliente.telefono= Console.ReadLine();

            Console.WriteLine("Escriba el nuevo  nacionalidad cliente:"); 
            cliente.nacionalidad = Console.ReadLine();

            Console.WriteLine("Escriba el nuevo  E_mail del cliente:"); 
            cliente.email = Console.ReadLine();
            
            Console.WriteLine("Escriba el nuevo  direccion del cliente:"); 
            cliente.direccionCliente = Console.ReadLine();

            _repoCliente.UpdateCliente(cliente);
        }

        public static void AgregarCliente()
        {
            Console.WriteLine("Agregar un cliente");
            //Instanciar la entidad 
            Cliente clienteNuevo = new Cliente();

            // Obtener los datos del cliente
            Console.WriteLine("Escriba el nit del cliente:");
            clienteNuevo.nit = Console.ReadLine();

            Console.WriteLine("Escriba el nombre del cliente:");
            clienteNuevo.nombre = Console.ReadLine();

            Console.WriteLine("Escriba el apellido del cliente:"); 
            clienteNuevo.apellidos = Console.ReadLine();

            Console.WriteLine("Escriba el telefono del cliente:"); 
            clienteNuevo.telefono= Console.ReadLine();

            Console.WriteLine("Escriba el nacionalidad cliente:"); 
            clienteNuevo.nacionalidad = Console.ReadLine();

            Console.WriteLine("Escriba el E_mail del cliente:"); 
            clienteNuevo.email = Console.ReadLine();
            
            Console.WriteLine("Escriba el direccion del cliente:"); 
            clienteNuevo.direccionCliente = Console.ReadLine();
            
            //Invocamos al Repositorio
            _repoCliente.AddCliente(clienteNuevo);
        }
    }
}
