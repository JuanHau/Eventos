using System;

namespace Eventos
{
    public class ValidarEvento
    {
        public string FormatoMensaje(string evento)
        {
            string resultado;
            string[] contenido = evento.Split(',');
            if (contenido.Length > 0 && contenido.Length == 2)
            {
                resultado = contenido[0] + ValidaFecha(contenido[1]);
            }
            else
            {
                resultado = "Formato incorrecto del evento";
            }

            return resultado;
        }

        public string ValidaFecha(string fecha)
        {
            try
            {
                string tiempo = string.Empty;
                DateTime.TryParse(fecha, out DateTime fechaEvento);
                if (fechaEvento == DateTime.MinValue)
                {
                    throw new ArgumentException("Formato de fecha incorrecto");
                }

                double miliSegundos = (new DateTime(2020, 01, 01) - fechaEvento).TotalMilliseconds;

                TimeSpan intervalo = TimeSpan.FromMilliseconds(miliSegundos);

                tiempo = ValidaMes(intervalo.Days);

                if (string.IsNullOrEmpty(tiempo))
                {
                    tiempo = ValidaEscala(intervalo.Days, "día(s)");
                }

                if (string.IsNullOrEmpty(tiempo))
                {
                    tiempo = ValidaEscala(intervalo.Hours, "hora(s)");
                }

                if (string.IsNullOrEmpty(tiempo))
                {
                    tiempo = ValidaEscala(intervalo.Minutes, "minuto(s)");
                }

                if (string.IsNullOrEmpty(tiempo))
                {
                    tiempo = ValidaEscala(intervalo.Seconds, "segundo(s)");
                }

                return tiempo;
            }
            catch (Exception Ex)
            {
                return "Ocurrió el siguiente error al validar la fecha: " + Ex.Message;
            }
        }

        public string ValidaMes(int dias)
        {
            string resultado = string.Empty;

            if ((dias / 30.436875) >= 1)
            {
                resultado = " ocurrió hace " + ((int)(dias / 30.436875)).ToString() + " mes(s)";
            }
            else if((dias / 30.436875) <= -1)
            {
                resultado = " ocurrirá dentro de " + ((int)(dias / 30.436875 * -1)).ToString() + " mes(s)";
            }

            return resultado;
        }

        public string ValidaEscala(int valor, string escala)
        {
            string resultado = string.Empty;

            if(valor > 0)
            {
                resultado = " ocurrió hace " + valor + " " + escala;
            }
            else if(valor <= -1)
            {
                resultado = " ocurrirá dentro de " + valor * -1 + " " + escala;
            }

            return resultado;
        }
    }
}
