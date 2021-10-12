using AutoMapper;
using VedaSystem.Application.ViewModels;
using VedaSystem.Domain.Models;

namespace VedaSystem.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Usuario, UsuarioViewModel>()
                .ForMember(x => x.TiposUsuario, opt => opt.Ignore())
                .ForMember(x => x.TipoUsuarioName, opt => opt.Ignore())
                .ForMember(x => x.ImagemUpload, opt => opt.Ignore())
                .ForMember(x => x.Foto, opt => opt.Ignore());
            CreateMap<Paciente, PacienteViewModel>();
            CreateMap<Agenda, AgendaViewModel>();
            CreateMap<Email, EmailViewModel>();
            CreateMap<EstoqueMaterial, EstoqueMaterialViewModel>();
            CreateMap<Horario, HorarioTerapeutaViewModel>();
            CreateMap<Log, LogViewModel>();
            CreateMap<MaterialTerapia, MaterialTerapiaViewModel>();
            CreateMap<Medicamento, MedicamentoViewModel>();
            CreateMap<Prescricao, PrescricaoViewModel>();
            CreateMap<Terapeuta, TerapeutaViewModel>()
                .ForMember(x => x.ImagemUpload, opt => opt.Ignore());
            
            CreateMap<Terapia, TerapiaViewModel>();
            CreateMap<Tradutor, TradutorViewModel>();
            CreateMap<Transmissao, TransmissaoViewModel>();
            CreateMap<Depoimento, DepoimentoViewModel>();
            CreateMap<FichaClinicaPaciente, FichaClinicaPacienteViewModel>();
            CreateMap<QuestionarioPosDiagnostico, QuestionarioPosDiagnosticoViewModel>();


        }
    }
}
