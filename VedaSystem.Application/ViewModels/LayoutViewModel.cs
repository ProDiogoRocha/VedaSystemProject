using System;
using VedaSystem.Domain.Models;

namespace VedaSystem.Application.ViewModels
{
    [Serializable]
    public class LayoutViewModel
    {
        public Usuario Usuario { get; set; }
        public TerapeutaViewModel Terapeuta { get; set; }
        public Email Email { get; set; }
    }
}
