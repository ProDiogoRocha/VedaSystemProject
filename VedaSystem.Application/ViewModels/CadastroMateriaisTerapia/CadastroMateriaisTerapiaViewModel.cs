using System;
using System.Collections.Generic;

namespace VedaSystem.Application.ViewModels.CadastroMateriaisTerapia
{
    public class CadastroMateriaisTerapiaViewModel
    {
        public CadastroMateriaisTerapiaViewModel() { }
        public CadastroMateriaisTerapiaViewModel(Guid? idMaterial) { }

        public CadastroMateriaisTerapiaViewModel(Guid? idMaterial, int quantidade, Guid? idTerapia, Guid? idEstoqueMaterial, List<EstoqueMaterialViewModel> listaEstoqueDeMateriais) : this(idMaterial)
        {
            Quantidade = quantidade;
            IdTerapia = idTerapia;
            IdEstoqueMaterial = idEstoqueMaterial;
            ListaEstoqueDeMateriais = listaEstoqueDeMateriais;
        }

        public Guid? IdMaterial { get; set; }
        public int Quantidade { get; set; }
        public Guid? IdTerapia { get; set; }
        public Guid? IdEstoqueMaterial { get; set; }
        public List<EstoqueMaterialViewModel> ListaEstoqueDeMateriais { get; set; }
    }
}