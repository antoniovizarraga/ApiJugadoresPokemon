using DAL;
using ENT;

namespace BL
{
    public class ManejadoraJugadoresBL
    {
        /// <summary>
        /// Función que inserta un <see cref="Jugador"/> metido por parámetro en la DAL. Pre: Los campos a insertar del <see cref="Jugador"/> no pueden ser nulos. Post: Devuelve un <see langword="bool"/>
        /// devolviendo <see langword="true"/> si se pudo insertar correctamente, o <see langword="false"/> en caso contrario.
        /// </summary>
        /// <param name="player">El objeto <see cref="Jugador"/> a insertar en la DAL.</param>
        /// <returns>Un <see langword="bool"/> indicando si se pudo insertar en la DAL. En dicho caso, devolverá <see langword="true"/>. O <see langword="false"/>
        /// en caso contrario.</returns>
        public static bool InsertarJugadorBL(Jugador player)
        {
            return ManejadoraJugadoresDAL.InsertarJugador(player);
        }
    }
}
