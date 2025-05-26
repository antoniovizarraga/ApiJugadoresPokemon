using DAL;
using ENT;

namespace BL
{
    public class ClsConexionBL
    {
        /// <summary>
        /// Función que devuelve la cadena de conexión necesaria para acceder a la BBDD de jugadores.
        /// </summary>
        /// <returns>Un string que contiene toda la información de la BBDD de Jugadores.</returns>
        public static string GetConnectionStringBL()
        {
            return ClsConexion.GetConnectionString();
        }
    }
}
