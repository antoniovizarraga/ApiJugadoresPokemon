using ENT;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class ManejadoraJugadoresDAL
    {
        /// <summary>
        /// Función que inserta un <see cref="Jugador"/> metido por parámetro en la BBDD. Pre: Los campos a insertar del <see cref="Jugador"/> no pueden ser nulos. Post: Devuelve un <see langword="bool"/>
        /// devolviendo <see langword="true"/> si se pudo insertar correctamente, o <see langword="false"/> en caso contrario.
        /// </summary>
        /// <param name="player">El objeto <see cref="Jugador"/> a insertar en la BBDD.</param>
        /// <returns>Un <see langword="bool"/> indicando si se pudo insertar en la BBDD. En dicho caso, devolverá <see langword="true"/>. O <see langword="false"/>
        /// en caso contrario.</returns>
        public static bool InsertarJugador(Jugador player)
        {
            bool res = false;

            int temp;

            SqlConnection miConexion = new SqlConnection();



            SqlCommand miComando = new SqlCommand();
            miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = player.Nombre;
            miComando.Parameters.Add("@puntuacion", System.Data.SqlDbType.Int).Value = player.Score;



            miConexion.ConnectionString = ClsConexion.GetConnectionString();

            try
            {
                miConexion.Open();

                miComando.CommandText = "INSERT INTO Jugador (nombreJugador, puntuacionJugador) VALUES (@nombre, @puntuacion)";
                miComando.Connection = miConexion;

                temp = miComando.ExecuteNonQuery();



                miConexion.Close();

                if (temp != 0)
                {
                    res = true;
                }

            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return res;
        }
    }
}
