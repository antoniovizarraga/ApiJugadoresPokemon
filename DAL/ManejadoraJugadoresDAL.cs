using ENT;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class ManejadoraJugadoresDAL
    {

        /// <summary>
        /// Función que devuelve un <see cref="Jugador"/> de la BBDD por el ID pasado por parámetro. Pre: El ID del jugador debe existir en la BBDD. Si no, devolverá un
        /// <see cref="Jugador"/> con Id = -1 (Que significa que no ha sido encontrado). Post: Devuelve un <see cref="Jugador"/> relleno con los valores de la BBDD.
        /// Si no, devolverá un <see cref="Jugador"/> con Id = -1.
        /// </summary>
        /// <param name="id">El ID con el que buscar al <see cref="Jugador"/> en la BBDD.</param>
        /// <returns>Un <see cref="Jugador"/> relleno con los valores de la BBDD. Si no, devolverá un <see cref="Jugador"/> con Id = -1.</returns>
        public static Jugador ObtenerJugadorPorId(int id)
        {
            /* Esta función no hace falta para el ejercicio, pero lo hago por practicar simplemente. */

            string nombreJugador = "";

            int puntuacionJugador = 0;

            Jugador player = new Jugador(-1, -1000, "");

            SqlConnection miConexion = new SqlConnection();



            SqlCommand miComando = new SqlCommand();
            miComando.Parameters.Add("@idPlayer", System.Data.SqlDbType.Int).Value = id;

            SqlDataReader miLector;



            miConexion.ConnectionString = ClsConexion.GetConnectionString();

            try
            {
                miConexion.Open();

                miComando.CommandText = "SELECT * FROM Jugador WHERE idJugador = @idPlayer";
                miComando.Connection = miConexion;

                miLector = miComando.ExecuteReader();


                // Si hay líneas en el lector

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        if (miLector["idJugador"] != DBNull.Value)
                        {
                            id = (int)miLector["idJugador"];
                        }

                        if (miLector["puntuacionJugador"] != DBNull.Value)
                        {
                            puntuacionJugador = (int)miLector["puntuacionJugador"];
                        }

                        if (miLector["nombreJugador"] != DBNull.Value)
                        {
                            nombreJugador = (string)miLector["nombreJugador"];
                        }
                        player = new Jugador(id, puntuacionJugador, nombreJugador);
                    }
                }

                miLector.Close();
                miConexion.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return player;
        }

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
