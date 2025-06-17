namespace API_Futebol.Entities
{
    public class Jogadores
    {
        public int JogadoresId { get; set; }
        public string? Nome { get; set; }
        public string? Apelido { get; set; }

        public string? Posicao { get; set; }

        public bool Presenca { get; set; }

        public int GruposId { get; set; }

        public int FutebolId { get; set; }
    }
}
