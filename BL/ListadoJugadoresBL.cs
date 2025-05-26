using DAL;
using ENT;

namespace BL
{
    public class ListadoJugadoresBL
    {
        /// <summary>
        /// Función que devuelve un <see cref="List{Jugador}"/> relleno de objetos de tipo <see cref="Jugador"/> de la DAL ordenados por la puntuación más alta.
        /// </summary>
        /// <returns>Un <see cref="List{Jugador}"/> relleno de objetos de tipo <see cref="Jugador"/>.</returns>
        public static List<Jugador> ObtenerListadoJugadoresBL()
        {
            return ListadoJugadores.ObtenerListadoJugadores();
        }
    }
}
