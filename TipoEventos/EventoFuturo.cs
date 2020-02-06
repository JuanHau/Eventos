using Eventos.TipoEventos.Interfaces;
using Eventos.Utilerias;

namespace Eventos.TipoEventos
{
    public class EventoFuturo : IEvent
    {
        public string Nombre { get; set; }
        public int Duracion { get; set; }
        public Escala Escala { get; set; }

        public EventoFuturo(string nombre, int duracion, Escala escala)
        {
            Nombre = nombre;
            Duracion = duracion;
            Escala = escala;
        }

        public override string ToString()
        {
            string resultado;
            string escala = string.Empty;
            switch (Escala)
            {
                case Escala.Mes:
                    escala = Duracion > 1 ? "meses" : "mes";
                    break;
                case Escala.Dia:
                    escala = Duracion > 1 ? "días" : "día";
                    break;
                case Escala.Hora:
                    escala = Duracion > 1 ? "horas" : "hora";
                    break;
                case Escala.Minuto:
                    escala = Duracion > 1 ? "minutos" : "minuto";
                    break;
                case Escala.Segundo:
                    escala = Duracion > 1 ? "segundos" : "segundo";
                    break;
            }
            resultado = string.Format("{0} ocurrirá dentro de {1} {2}", Nombre, Duracion, escala);

            return resultado;
        }
    }
}
