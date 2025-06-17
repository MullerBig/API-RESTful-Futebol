using API_Futebol.Context;
using API_Futebol.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API_Futebol.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FutebolController : ControllerBase
    {
        private readonly FutebolDBContext _context;
        public FutebolController(FutebolDBContext context)
        {
            _context = context;
        }

        [HttpPost("CriarFutebol")]
        public ActionResult CriarFutebol(Futebol futebol)
        {
            _context.Add(futebol);
            _context.SaveChanges();
            return Ok(futebol);
        }

        [HttpGet("SelecionarFutebol")]
        public ActionResult SelecionarFutebol(int FutebolId)
        {
            var futebol = _context.Futebols.Find(FutebolId);
            if (futebol == null)
            {
                return NotFound();
            }

            return Ok(futebol);
        }

        [HttpPut("AtualizarFutebol")]
        public ActionResult AtualizarFutebol(int FutebolId, Futebol futebol)
        {
            var fulbito = _context.Futebols.Find(FutebolId);
            if (fulbito == null)
                return NotFound();
            fulbito.Data = futebol.Data;
            fulbito.Horario = futebol.Horario;
            fulbito.Quadra = futebol.Quadra;
            fulbito.Rua = futebol.Rua;
            fulbito.Complemento = futebol.Complemento;
            fulbito.Bairro = futebol.Bairro;
            fulbito.Cidade = futebol.Cidade;

            _context.Futebols.Update(fulbito);
            _context.SaveChanges();
            return Ok(fulbito);
        }

        [HttpDelete("DeletarFutebol")]
        public ActionResult DeletarFutebol(int FutebolId)
        {
            var fulbito = _context.Futebols.Find(FutebolId);
            if (fulbito == null)
                return NotFound();
            _context.Futebols.Remove(fulbito);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
