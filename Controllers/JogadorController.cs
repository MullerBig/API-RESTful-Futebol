using API_Futebol.Context;
using API_Futebol.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Futebol.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JogadorController : ControllerBase
    {
        private readonly FutebolDBContext _context;
        public JogadorController(FutebolDBContext context)
        {
            _context = context;
        }

        [HttpPost("CriarJogador")]
        public ActionResult CriarJogador([FromBody]Jogadores jogadores)
        {
            _context.Add(jogadores);
            _context.SaveChanges();
            return Ok(jogadores);
        }

        [HttpGet("SelecionarJogador")]
        public ActionResult SelecionarJogador(int JogadorId)
        {
            var jogadores = _context.Jogadores.Find(JogadorId);
            if (jogadores == null)
            {
                return NotFound();
            }

            return Ok(jogadores);
        }

        [HttpGet("ListarJogadores")]
        public ActionResult ListarJogadores()
        {
            var jogadores = _context.Jogadores.ToList();

            if (jogadores == null || jogadores.Count == 0)
            {
                return NotFound("Nenhum jogador encontrado.");
            }

            return Ok(jogadores);
        }


        [HttpPut("AtualizarJogador")]
        public ActionResult AtualizarJogador(int JogadorId, Jogadores jogadores)
        {
            var fulbito = _context.Jogadores.Find(JogadorId);
            if (fulbito == null)
                return NotFound();
            fulbito.Nome = jogadores.Nome;
            fulbito.Apelido = jogadores.Apelido;
            fulbito.Posicao = jogadores.Posicao;
            fulbito.Presenca = jogadores.Presenca;
            fulbito.GruposId = jogadores.GruposId;
            fulbito.FutebolId = jogadores.FutebolId;

            _context.Jogadores.Update(fulbito);
            _context.SaveChanges();
            return Ok(fulbito);
        }

        [HttpDelete("DeletarJogador")]
        public ActionResult DeletarJogador(int JogadorId)
        {
            var fulbito = _context.Jogadores.Find(JogadorId);
            if (fulbito == null)
                return NotFound();
            _context.Jogadores.Remove(fulbito);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
