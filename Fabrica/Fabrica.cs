using Eventos.TipoEventos;
using Eventos.TipoEventos.Interfaces;
using Eventos.Utilerias;

namespace Eventos.Fabrica
{
    public class Fabrica
    {
        public LeerArchivo LeerArchivo { get; set; }

        public ValidaFecha ValidaFecha { get; set; }

        public IEvent CrearInstancia(Contenedor contenedor)
        {
            IEvent evento = null;
            switch (contenedor.Tipo)
            {
                case Tipo.Futuro:
                    evento = new EventoFuturo(contenedor.Nombre, contenedor.Duracion, contenedor.Escala);
                    break;
                case Tipo.Pasado:
                    evento = new EventoPasado(contenedor.Nombre, contenedor.Duracion, contenedor.Escala);
                    break;
            }

            return evento;
        }

        public void Iniciar()
        {
            ValidaFecha = new ValidaFecha();
            LeerArchivo = new LeerArchivo(ValidaFecha);
        }
    }
}
