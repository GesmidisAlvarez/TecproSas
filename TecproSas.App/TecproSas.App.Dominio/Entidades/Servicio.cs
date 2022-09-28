using System;
using System.ComponentModel.DataAnnotations;
namespace TecproSas.App.Dominio
{
public class Servicio
{

[Key]
public int servicioId { get ; set;}

[MaxLength (40)]
public string nombServicio { get ; set ;}
public int valor { get ; set ;}
public DateTime fechaInicio { get ; set ;}
[MaxLength (255)]
public string descripcion { get ; set ;}




}
}