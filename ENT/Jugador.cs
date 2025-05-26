using System.Text.Json.Serialization;

namespace ENT
{
    public class Jugador
    {

        #region Propiedades

        [JsonPropertyName("idJugador")]
        public int Id { get; }

        [JsonPropertyName("puntuacionJugador")]
        public int Score { get; set; }

        [JsonPropertyName("nombreJugador")]
        public string Nombre { get; set; }

        #endregion

        #region Constructores

        public Jugador(int id, int score, string nombre)
        {
            Id = id;
            Score = score;
            Nombre = nombre;
        }

        

        #endregion
    }
}
