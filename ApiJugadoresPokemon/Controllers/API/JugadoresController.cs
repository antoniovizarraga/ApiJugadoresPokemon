using BL;
using ENT;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiJugadoresPokemon.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class JugadoresController : ControllerBase
    {
        // GET: api/<JugadoresController>
        [HttpGet]
        public IActionResult Get()
        {
            IActionResult res;

            List<Jugador> listadoJugadores = new List<Jugador>();

            try
            {
                listadoJugadores = ListadoJugadoresBL.ObtenerListadoJugadoresBL();
            }
            catch (Exception ex)
            { 
                res = BadRequest();
            }

            if (listadoJugadores.Count == 0)
            { 
                res = NoContent();
            } else
            {
                res = Ok(listadoJugadores);
            }

            return res;
        }

        // GET api/<JugadoresController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IActionResult res;

            Jugador player = new Jugador(-2, -2000, "");

            try
            {
                player = ManejadoraJugadoresBL.ObtenerJugadorPorIdBL(id);

                if (player != null && player.Id != -1)
                {
                    res = Ok(player);
                }
                else
                {
                    res = NotFound();
                }

            }
            catch (Exception ex)
            { 
                res = BadRequest();
            }

            return res;
        }

        // POST api/<JugadoresController>
        [HttpPost]
        public IActionResult Post([FromBody] Jugador player)
        {
            IActionResult res;
            bool temp = false;

            try
            {
                temp = ManejadoraJugadoresBL.InsertarJugadorBL(player);

                if (temp)
                {
                    res = Ok();
                }
                else
                {
                    res = NotFound();
                }

            }
            catch (Exception ex)
            {
                res = BadRequest();
            }

            return res;
        }
    }
}
