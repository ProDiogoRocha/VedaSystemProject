using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VedaSystem.Application.Interfaces;
using VedaSystem.Domain.Enums;
using VedaSystem.Domain.Interfaces;

namespace VedaSystem.Application.ViewModels
{
    public class UsuarioViewModel
    {
        private readonly IUsuarioRepository _repository;
        private readonly IUsuarioService _usuarioService;

        public UsuarioViewModel() { }

        public UsuarioViewModel(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;

            TiposUsuario = GetTipoUsuario();
        }

        public UsuarioViewModel(IUsuarioRepository repository)
        {
            _repository = repository;

            TiposUsuario = GetTipoUsuario();
        }

        public UsuarioViewModel(Guid? id, string nomeDeUsuario, string senha, DateTime dataNascimento, string endereco, string email, DateTime dataCadastro, TipoUsuario tipoUsuario)
        {
            Id = id;
            NomeDeUsuario = nomeDeUsuario;
            Senha = senha;
            ConfirmeSenha = senha;
            DataNascimento = dataNascimento;
            Endereco = endereco;
            Email = email;
            DataCadastro = dataCadastro;
            TipoUsuario = tipoUsuario;
        }
        public UsuarioViewModel(string nomeDeUsuario, string senha, DateTime dataNascimento, string endereco, string email, DateTime dataCadastro, TipoUsuario tipoUsuario)
        {
            NomeDeUsuario = nomeDeUsuario;
            Senha = senha;
            ConfirmeSenha = senha;
            DataNascimento = dataNascimento;
            Endereco = endereco;
            Email = email;
            DataCadastro = dataCadastro;
            TipoUsuario = tipoUsuario;
        }

        public UsuarioViewModel(Guid? id, string nomeDeUsuario, string senha, DateTime dataNascimento, string endereco, string email, DateTime dataCadastro, TipoUsuario tipoUsuario, byte[] foto)
        {
            Id = id;
            NomeDeUsuario = nomeDeUsuario;
            Senha = senha;
            ConfirmeSenha = senha;
            DataNascimento = dataNascimento;
            Endereco = endereco;
            Email = email;
            DataCadastro = dataCadastro;
            TipoUsuario = tipoUsuario;
            Foto = foto;
        }

        [Key]
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "O preenchimento do campo Nome de Usuario é obrigatório", AllowEmptyStrings = false)]
        [StringLength(80, ErrorMessage = "O Nome deve conter entre 5 e 80 caracteres", MinimumLength = 5)]
        [Display(Name = "Nome de Usuario")]
        public string NomeDeUsuario { get; set; }

        [Required(ErrorMessage = "O preenchimento do campo Senha é obrigatório", AllowEmptyStrings = false)]
        [StringLength(9, ErrorMessage = "A senha deve conter entre 6 e 9 caracteres", MinimumLength = 6)]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required(ErrorMessage = "O preenchimento do campo Confirmar Senha é obrigatório")]
        [StringLength(9, ErrorMessage = "A senha deve conter entre 6 e 9 caracteres", MinimumLength = 6)]
        [Display(Name = "Confirmar Senha")]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("ConfirmeSenha")]
        public string ConfirmeSenha { get; set; }

        [Required(ErrorMessage = "O preenchimento do campo Data de Nascimento é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime? DataNascimento { get; set; }

        [Required(ErrorMessage = "O preenchimento do campo Endereço é obrigatório", AllowEmptyStrings = false)]
        [StringLength(80, ErrorMessage = "O endereço deve conter entre 20 e 80 caracteres", MinimumLength = 20)]

        [Display(Name = "Endereço")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "O preenchimento do campo E-mail é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "Foto")]
        public IFormFile ImagemUpload { get; set; }

        public byte[] Foto { get; set; }


        [DataType(DataType.Text)]
        [Display(Name = "Perfis de usuário : ")]
        public IEnumerable<SelectListItem> TiposUsuario { get; set; }

        public TipoUsuario TipoUsuario { get; set; }

        public string TipoUsuarioName { get; set; }

        public DateTime? DataCadastro { get; set; } = DateTime.Now;

        public IList<SelectListItem> GetTipoUsuario()
        {
            IList<SelectListItem> selItems = new List<SelectListItem>();

            if (_usuarioService != null)
            {
                selItems = _usuarioService.GetPerfisUsuario();
            }
            else if (_repository != null)
            {
                selItems = _repository.GetPerfisUsuario();
            }
            return selItems;
        }

        public void GetTipoUsuarioEnum()
        {
            TipoUsuario tpUsuario = 0;

            switch (this.TipoUsuarioName)
            {
                case "Admin":
                    tpUsuario = TipoUsuario.Admin;
                    break;
                case "Terapeuta":
                    tpUsuario = TipoUsuario.Terapeuta;
                    break;
                case "Paciente":
                    tpUsuario = TipoUsuario.Paciente;
                    break;
                case "FreeUser":
                    tpUsuario = TipoUsuario.FreeUser;
                    break;
            }
            this.TipoUsuario = tpUsuario;
        }

        public void GetTipoUsuarioText()
        {
            string tpUsuario = "";

            switch (this.TipoUsuario)
            {
                case TipoUsuario.Admin:
                    tpUsuario = "Admin";
                    break;
                case TipoUsuario.Terapeuta:
                    tpUsuario = "Terapeuta";
                    break;
                case TipoUsuario.Paciente:
                    tpUsuario = "Paciente";
                    break;
                case TipoUsuario.FreeUser:
                    tpUsuario = "FreeUser";
                    break;
            }
            this.TipoUsuarioName = tpUsuario;
        }

        public  string RetornaPerfil()
        {
            string tipo = "";
            switch (this.TipoUsuario)
            {
                case TipoUsuario.Admin:
                    tipo = "Admin";
                    break;
                case TipoUsuario.Terapeuta:
                    tipo = "Terapeuta";
                    break;
                case TipoUsuario.Paciente:
                    tipo = "Paciente";
                    break;
                case TipoUsuario.FreeUser:
                    tipo = "FreeUser";
                    break;
            }

            return tipo;
        }
    }
}
