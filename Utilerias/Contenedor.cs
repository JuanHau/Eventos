using Eventos.TipoEventos;

namespace Eventos.Utilerias
{
    public class Contenedor
    {
        public TipoEvento Tipo { get; set; }
        public EscalaTiempo Escala { get; set; }
        public int Duracion { get; set; }
        public string Nombre { get; set; }
    }
}
