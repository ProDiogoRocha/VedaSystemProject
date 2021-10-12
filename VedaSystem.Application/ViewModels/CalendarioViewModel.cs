using System.Collections.Generic;

namespace VedaSystem.Application.ViewModels
{
    public class CalendarioViewModel
    {
        public IEnumerable<TerapiaViewModel> Terapias { get; set; }
        public TerapiaViewModel TerapiaSelecionada { get; set; }
        public IEnumerable<TerapeutaViewModel> Terapeutas { get; set; }
        public TerapeutaViewModel TerapeutaSelecionado { get; set; }
        public IEnumerable<HorarioTerapeutaViewModel> Horarios { get; set; }
        public string HorariosJson { get; set; }
        public string NomeTerapeuta { get; set; }
    }
}
