using System;
using System.Collections.Generic;
namespace SalaDeEscape.Models
{
    /*Crear la clase estática Escape.cs
		Debe contener los siguientes atributos:
			List<string> IncongnitasSalas
			int EstadoJuego;
		Y el siguiente Método:
			bool ResolverSala(int Sala, string Incognita)*/
    public static class Escapes
    {

        private static List <string> _incongnitasSalas= new List <string>(){"ADCAHH","137","SA07","12396"}; 
        private static int _estadoJuego = 1;
        public static int EstadoJuego
        {
              get { return _estadoJuego;}
        }
        public static bool resolverSala(int sala, string incognita)
        {
             if(_incongnitasSalas[sala-1]==incognita)
             {
                 _estadoJuego=sala+1;
                  return true;
             }
             else
             {  _estadoJuego=sala;
                  return false;
             }
        }
       
    }
}
 