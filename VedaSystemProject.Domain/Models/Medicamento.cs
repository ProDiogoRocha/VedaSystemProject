using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using VedaSystemProject.Domain.Enums;
using VedaSystemProject.Domain.Interfaces;

namespace VedaSystemProject.Domain.Models
{
    [Table("Medicamento")]
    public class Medicamento : IBaseModel
    {
        public Guid? Id { get; set; }
        public string Nome { get; set; }
        public string Composicao { get; set; }
        public string Laboratorio { get; set; }
        public TipoMedicamento TipoMedicamento { get; set; }
        public virtual ICollection<Prescricao> Prescricoes { get; set; }
    }
}
