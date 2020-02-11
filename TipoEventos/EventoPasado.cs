using Eventos.TipoEventos.Interfaces;
using Eventos.Utilerias;

namespace Eventos.TipoEventos
{
    public class EventoPasado : IEvento
    {
        public string Nombre { get; set; }
        public int Duracion { get; set; }
        public EscalaTiempo Escala { get; set; }

        public EventoPasado(string nombre, int duracion, EscalaTiempo escala)
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
                case EscalaTiempo.Mes:
                    escala = Duracion > 1 ? "meses" : "mes";
                    break;
                case EscalaTiempo.Dia:
                    escala = Duracion > 1 ? "días" : "día";
                    break;
                case EscalaTiempo.Hora:
                    escala = Duracion > 1 ? "horas" : "hora";
                    break;
                case EscalaTiempo.Minuto:
                    escala = Duracion > 1 ? "minutos" : "minuto";
                    break;
            }
            resultado = string.Format("{0} ocurrió hace {1} {2}", Nombre, Duracion, escala);

            return resultado;
        }
    }
}
