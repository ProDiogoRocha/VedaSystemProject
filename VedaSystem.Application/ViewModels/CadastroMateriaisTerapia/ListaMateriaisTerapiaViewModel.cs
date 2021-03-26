using System;
using System.ComponentModel.DataAnnotations;

namespace VedaSystem.Application.ViewModels.CadastroMateriaisTerapia
{
    public class ListaMateriaisTerapiaViewModel
    {
        public ListaMateriaisTerapiaViewModel() { }
        public ListaMateriaisTerapiaViewModel(Guid? idMT, int quantidadeMT, Guid? idEM, string descricaoEM, string modeloEM, string marcaEM, int quantidadeEM, Guid? idTErapia)
        {
            IdMT = idMT;
            QuantidadeMT = quantidadeMT;
            IdEM = idEM;
            DescricaoEM = descricaoEM;
            ModeloEM = modeloEM;
            MarcaEM = marcaEM;
            QuantidadeEM = quantidadeEM;
            IdTErapia = idTErapia;
        }

        [Key]
        public Guid? IdMT { get; set; }
        public int QuantidadeMT { get; set; }
        public Guid? IdEM { get; set; }
        public string DescricaoEM { get; set; }
        public string ModeloEM { get; set; }
        public string MarcaEM { get; set; }
        public int QuantidadeEM { get; set; }
        public Guid? IdTErapia { get; set; }
    }
}