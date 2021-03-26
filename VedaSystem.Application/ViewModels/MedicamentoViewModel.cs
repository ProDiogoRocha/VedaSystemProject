using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VedaSystem.Domain.Enums;

namespace VedaSystem.Application.ViewModels
{
    public class MedicamentoViewModel
    {
        [Key]
        public Guid? Id { get; set; }
        public string Nome { get; set; }
        public string Composicao { get; set; }
        public string Laboratorio { get; set; }
        public TipoMedicamento TipoMedicamento { get; set; }
        public virtual IList<PrescricaoViewModel> Prescricoes { get; set; }
    }
}