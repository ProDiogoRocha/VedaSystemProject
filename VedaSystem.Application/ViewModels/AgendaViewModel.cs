using System;
using VedaSystem.Domain.Enums;

namespace VedaSystem.Application.ViewModels
{
    public class AgendaViewModel
    {
        public Guid? Id { get; set; }
        public Guid? PacienteId { get; set; }
        public DiaSemana DiaSemana { get; set; }
        public int DiaMes { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }
        public Guid? TerapiaId { get; set; }
        public Guid? TerapeutaId { get; set; }
    }
}
