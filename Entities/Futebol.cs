namespace API_Futebol.Entities
{
    public class Futebol
    {
        public int FutebolId { get; set; }

        public DateOnly Data { get; set; }

        public TimeOnly Horario { get; set; }

        public string? Quadra { get; set; }

        public string? Rua { get; set; }

        public string? Complemento { get; set; }

        public string? Bairro { get; set; }

        public string? Cidade { get; set; }


    }
}
