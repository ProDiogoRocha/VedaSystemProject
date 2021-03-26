using System.ComponentModel.DataAnnotations;

namespace VedaSystem.Domain.Enums
{
    public enum DiaSemana
    {
        [Display(Name = "domingo")]
        domingo = 1,
        [Display(Name = "segunda-feira")]
        segunda = 2,
        [Display(Name = "terça-feira")]
        terca = 3,
        [Display(Name = "quarta-feira")]
        quarta = 4,
        [Display(Name = "quinta-feira")]
        quinta = 5,
        [Display(Name = "sexta-feira")]
        sexta = 6,
        [Display(Name = "sabado")]
        sabado = 7
    }
}
