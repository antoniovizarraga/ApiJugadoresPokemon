namespace ENT
{
    public class Jugador
    {

        #region Propiedades

        public int Id { get; }

        public int Score { get; set; }

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
