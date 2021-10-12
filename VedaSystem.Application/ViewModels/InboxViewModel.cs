using System.Collections.Generic;

namespace VedaSystem.Application.ViewModels
{
    public class InboxViewModel
    {
        public IEnumerable<EmailMessageViewModel> EmailMessages { get; set; }
        public int QtdRegistros { get; set; }
        public int QtdNaoLidos { get; set; }
    }
}
