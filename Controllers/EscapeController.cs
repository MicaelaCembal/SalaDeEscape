using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SalaDeEscape.Models;

namespace Escape.Controllers
{
    public class EscapeController : Controller
    {
    /*Action Methods:
    1.	Index: Retorna la View Index con la presentación de la sala
    2.	Comenzar() → Devuelve la view Habitacion1.cshtml
    3.	[HttpPost] Habitacion(int sala, string clave) → Verifica que la clave ingresada sea la correcta. 
    De ser así, retorna la View siguiente Habitacion2 (sala + 1). 
    De lo contrario, vuelve a la misma vista y llena el ViewBag.Error informando al usuario que la respuesta escrita fue incorrecta. 
    Realizar de la misma manera, los métodos por POST para Habitacion2, 
    Habitacion3 y Habitacion4. Esta última, en caso de recibir la respuesta correcta, debe devolver la vista victoria.html
    */
    public IActionResult Index()
        {
            return View();
        }
    public IActionResult Comenzar()
        {
            ViewBag.SalaActual=1; 
            return View("Habitacion1");
        }
    
    [HttpPost]
    public IActionResult Habitacion(int sala, string clave)
        {
            bool condicionError = false;
            if(Escapes.resolverSala(sala,clave)==true && sala!=4)
            {
                ViewBag.SalaActual=Escapes.EstadoJuego; 
                return View("Habitacion" + Escapes.EstadoJuego);
            }           
            else if(Escapes.resolverSala(sala,clave)==true && sala==4) 
            {
                return View("Victoria");
            }
            else
            {
               condicionError = true;
               ViewBag.Error = condicionError;
               ViewBag.SalaActual= Escapes.EstadoJuego;
               return View("Habitacion" + Escapes.EstadoJuego);
            }
        }
    }
}
