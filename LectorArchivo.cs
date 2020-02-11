using Eventos.Utilerias.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;

namespace Eventos
{
    public class LectorArchivo : ILectorArchivo
    {
        public List<string> LeerArchivo(string ruta)
        {
            List<string> eventos = new List<string>();

            if (!File.Exists(ruta))
            {
                throw new ArgumentException("El archivo no existe");
            }

            using (StreamReader stream = new StreamReader(ruta))
            {
                while (stream.Peek() > -1)
                {
                    string evento = stream.ReadLine();

                    eventos.Add(evento);

                }
            }

            return eventos;
        }
    }
}
