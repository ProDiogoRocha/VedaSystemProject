using AutoMapper;
using VedaSystem.Application.ViewModels;
using VedaSystem.Domain.Models;

namespace VedaSystem.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<UsuarioViewModel, Usuario>()
                .ForMember(x => x.TiposUsuario, opt => opt.Ignore())
                .ForMember(x=>x.Foto, opt=>opt.Ignore());
            CreateMap<PacienteViewModel, Paciente>();
            CreateMap<AgendaViewModel, Agenda > ();
            CreateMap<EmailViewModel, Email>();
            CreateMap<EstoqueMaterialViewModel, EstoqueMaterial>();
            CreateMap<HorarioTerapeutaViewModel, Horario>();
            CreateMap<LogViewModel, Log>();
            CreateMap<MaterialTerapiaViewModel, MaterialTerapia>();
            CreateMap<MedicamentoViewModel, Medicamento>();
            CreateMap<PrescricaoViewModel, Prescricao>();
            CreateMap<TerapeutaViewModel, Terapeuta>();
            CreateMap<TerapiaViewModel, Terapia>();
            CreateMap<TradutorViewModel, Tradutor>();
            CreateMap<TransmissaoViewModel, Transmissao>();
            CreateMap<DepoimentoViewModel, Depoimento>();
            CreateMap<FichaClinicaPacienteViewModel, FichaClinicaPaciente>();
            CreateMap<QuestionarioPosDiagnosticoViewModel, QuestionarioPosDiagnostico>();


        }
    }
}
