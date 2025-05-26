using ENT;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class ListadoJugadores
    {
        /// <summary>
        /// Función que devuelve un <see cref="List{Jugador}"/> relleno de objetos de tipo <see cref="Jugador"/> de la BBDD ordenados por la puntuación más alta.
        /// </summary>
        /// <returns>Un <see cref="List{Jugador}"/> relleno de objetos de tipo <see cref="Jugador"/>.</returns>
        public static List<Jugador> ObtenerListadoJugadores()
        {
            SqlConnection miConexion = new SqlConnection();

            List<Jugador> listadoJugadores = new List<Jugador>();

            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            Jugador player;

            int jugadorId = 0;

            string nombreJugador = "";

            int puntuacionJugador = 0;


            miConexion.ConnectionString = ClsConexion.GetConnectionString();

            try
            {
                miConexion.Open();

                miComando.CommandText = "SELECT * FROM Jugador ORDER BY puntuacionJugador desc";
                miComando.Connection = miConexion;

                miLector = miComando.ExecuteReader();


                // Si hay líneas en el lector

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {

                        if(miLector["idJugador"] != DBNull.Value)
                        {
                            jugadorId = (int)miLector["idJugador"];
                        }

                        if(miLector["puntuacionJugador"] != DBNull.Value)
                        {
                            puntuacionJugador = (int)miLector["puntuacionJugador"];
                        }

                        if(miLector["nombreJugador"] != DBNull.Value)
                        {
                            nombreJugador = (string)miLector["nombreJugador"];
                        }

                        player = new Jugador(jugadorId, puntuacionJugador, nombreJugador);

                        listadoJugadores.Add(player);
                    }
                }

                miLector.Close();
                miConexion.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return listadoJugadores;
        }
    }
}
