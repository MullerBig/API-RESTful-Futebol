using API_Futebol.Context;
using API_Futebol.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API_Futebol.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GruposController : ControllerBase
    {
        private readonly FutebolDBContext _context;
        public GruposController(FutebolDBContext context)
        {
            _context = context;
        }

        [HttpPost("CriarGrupos")]
        public ActionResult CriarGrupos(Grupos grupos)
        {
            _context.Add(grupos);
            _context.SaveChanges();
            return Ok(grupos);
        }

        [HttpGet("SelecionarGrupos")]
        public ActionResult SelecionarGrupos(int GruposId)
        {
            var grupos = _context.Grupos.Find(GruposId);
            if (grupos == null)
            {
                return NotFound();
            }

            return Ok(grupos);
        }

        [HttpPut("AtualizarGrupo")]
        public ActionResult AtualizarGrupos(int GruposId, Grupos grupos)
        {
            var fulbito = _context.Grupos.Find(GruposId);
            if (fulbito == null)
                return NotFound();
            fulbito.Nome = grupos.Nome;

            _context.Grupos.Update(fulbito);
            _context.SaveChanges();
            return Ok(fulbito);
        }

        [HttpDelete("DeletarGrupo")]
        public ActionResult DeletarGrupos(int GruposId)
        {
            var fulbito = _context.Grupos.Find(GruposId);
            if (fulbito == null)
                return NotFound();
            _context.Grupos.Remove(fulbito);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
