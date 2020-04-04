using System;
using System.ComponentModel.DataAnnotations;

namespace BL.TesteGol.API.ViewModels
{
    public class AirplaneViewModel
    {
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "O modelo deve ser informado.")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "A quantidade de passageiros deve ser informada.")]
        public int? QtdPassageiros { get; set; }

        public DateTime? DataCriacao { get; set; }
    }
}