using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GostosinhoEmpregos.Models
{
    public class VagaViewModel
    {
        public int Id { get; set; }
        public DateTime DataCadastro { get; set; }
        [DisplayName("Funcao")]
        public string Funcao { get; set; }
        [DisplayName("Descrição")]
        public string Descricao { get; set; }
        [DisplayName("Data de Validade")]
        public DateTime DataValidade { get; set; }
        [DisplayName("Cidade")]
        public string Cidade { get; set; }
        [DisplayName("Cpf")]
        public string Cpf { get; set; }

        [DisplayName("Nome do responsavel")]
        public string NomeResponsavel { get; set; }
    }
}
