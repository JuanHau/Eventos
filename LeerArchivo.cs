using Eventos.Utilerias;
using Eventos.Utilerias.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;

namespace Eventos
{
    public class LeerArchivo
    {
        protected readonly string _direccion = "C:\\BLUE OCEAN\\CAPACITACION\\Eventos\\eventos.txt";
        protected IValidaFecha _validaFecha;


        public LeerArchivo(IValidaFecha validaFecha)
        {
            _validaFecha = validaFecha;
        }

        public List<Contenedor> Leer()
        {
            //Referencia 01 de enero de 2020 00:00:00
            List<Contenedor> contenedors = new List<Contenedor>();
            try
            {
                if (!File.Exists(_direccion))
                {
                    throw new ArgumentException("El archivo no existe");
                }

                using (StreamReader stream = new StreamReader(_direccion))
                {
                    while (stream.Peek() > -1)
                    {
                        string evento = stream.ReadLine();

                        string[] contenido = evento.Split(',');
                        if (contenido.Length > 0 && contenido.Length == 2)
                        {
                            DateTime fecha = _validaFecha.ConvertirFecha(contenido[1]);
                            Contenedor contenedor = _validaFecha.ValidarTipo(fecha);

                            if(contenedor == null)
                            {
                                throw new ArgumentException("No se pudo validar la fecha");
                            }

                            contenedor.Nombre = contenido[0];
                            contenedors.Add(contenedor);
                        }
                        else
                        {
                            throw new ArgumentException("Formato incorrecto del evento");
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Ocurrió el siguiente error al leer el archivo: " + Ex.Message);
            }

            return contenedors;
        }
    }
}
