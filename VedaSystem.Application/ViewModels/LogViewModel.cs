using System;

namespace VedaSystem.Application.ViewModels
{
    public class LogViewModel
    {
        public Guid? Id { get; set; }
        public DateTime? Data { get; set; } = DateTime.Now;
        public Guid? IdUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string NomeComputador { get; set; }
        public string Controller_Action { get; set; }
        public string Servico_Metodo { get; set; }
        public string Repositorio_Metodo { get; set; }
        public string Informacao { get; set; }
        public string ObjetoJson { get; set; }
        public string Erro { get; set; }
        public string Excecao { get; set; }
    }
}
