namespace DAL
{
    public class ClsConexion
    {
        /// <summary>
        /// Función que devuelve la cadena de conexión necesaria para acceder a la BBDD de jugadores.
        /// </summary>
        /// <returns>Un string que contiene toda la información de la BBDD de Jugadores.</returns>
        public static string GetConnectionString()
        {
            return "server=alvaro-salvador.database.windows.net;database=alvaroDB;uid=usuario;pwd=LaCampana123;trustServerCertificate=true;";
        }
    }
}
