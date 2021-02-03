using System;
using System.ComponentModel.DataAnnotations;

namespace GostosinhoEmpregos.Models
{
    public class VagaViewModel
    {
        public int Id { get; set; }
        public DateTime DataCadastro { get; set; }
        [Display(Name ="Funcao")]
        [Required(ErrorMessage = "Por favor insira a funcao")]
        [StringLength(100,ErrorMessage ="Erro na quantidade de caracteres!",  MinimumLength = 3)]
        public string Funcao { get; set; }

        [Display(Name = "Descrição")]
        [StringLength(3000, ErrorMessage = "Erro na quantidade de caracteres!", MinimumLength = 50)]
        public string Descricao { get; set; }

        [Display(Name = "Data de validade")]
        public DateTime DataValidade { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Cidade é obrigatorio")]
        [Display(Name = "Cidade")]
        public string Cidade { get; set; }

        [Required (ErrorMessage = "CPF obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Cpf")]
        [DisplayFormat(DataFormatString = "{0:000.000.000-00}", ApplyFormatInEditMode = true)]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Cpf incorreto")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O nome do responsavel pela vaga é obrigatorio", AllowEmptyStrings = false)]
        [Display(Name = "Nome Completo do responsavel")]
        [StringLength(100,ErrorMessage = "Erro ao preencher o nome"  ,MinimumLength = 5)]
        public string NomeResponsavel { get; set; }
    }
}
