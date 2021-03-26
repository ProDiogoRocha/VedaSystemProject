using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using VedaSystem.Domain.Enums;

namespace VedaSystem.Domain.Models
{
    [Table("Medicamentos")]
    public class Medicamento
    {
        public Guid? Id { get; set; }
        public string Nome { get; set; }
        public string Composicao { get; set; }
        public string Laboratorio { get; set; }
        public TipoMedicamento TipoMedicamento { get; set; }
        public virtual IList<Prescricao> Prescricoes { get; set; }
    }
}
