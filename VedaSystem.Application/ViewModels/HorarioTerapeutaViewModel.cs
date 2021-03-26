using System;

namespace VedaSystem.Application.ViewModels
{
    public class HorarioTerapeutaViewModel
    {
        #region Identification
        public Guid? Id { get; set; }
        public Guid TerapeutaId { get; set; }
        public Guid TerapiaId { get; set; }
        #endregion

        #region DataHora
        public DateTime HorarioInicial { get; set; }
        public DateTime HorarioFinal { get; set; }
        public DateTime DiaInicial { get; set; }
        public DateTime DiaFinal { get; set; }
        public int Dia { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }
        #endregion

        #region repeate
        public bool Repeticao { get; set; }
        public bool Individual { get; set; }
        public int DuracaoConsultaEmMinutos { get; set; }
        public int Intervalo { get; set; }
        #endregion

        #region reserve
        public bool Reservado { get; set; }
        #endregion
    }
}