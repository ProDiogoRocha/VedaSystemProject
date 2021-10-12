namespace VedaSystem.Application.ViewModels
{
    public class Evento
    {
        public string Titulo { get; set; }

        public int InicioAno { get; set; }
        public int InicioMes { get; set; }
        public int InicioDia { get; set; }
        public int InicioHora { get; set; }
        public int InicioMinuto { get; set; }

        public int FimAno { get; set; }
        public int FimMes { get; set; }
        public int FimDia { get; set; }
        public int FimHora { get; set; }
        public int FimMinuto { get; set; }

        public bool TodoDia { get; set; }

        public string NomeDaClasseCor { get; set; }

        public bool Reservado { get; set; }
    }
}
