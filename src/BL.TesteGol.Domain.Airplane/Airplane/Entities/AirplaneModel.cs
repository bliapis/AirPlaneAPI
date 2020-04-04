using BL.TesteGol.Domain.Core.Models;
using FluentValidation;
using System;

namespace BL.TesteGol.Domain.Airplane.Airplane.Entities
{
    public class AirplaneModel : Entity<AirplaneModel>
    {
        #region construtores
        public AirplaneModel(string modelo, int qtdPassageiros)
        {
            Id = Guid.NewGuid();
            Modelo = modelo;
            QtdPassageiros = qtdPassageiros;
            DataCriacao = DateTime.Now;
        }

        public AirplaneModel() { } // constructor EF
        #endregion

        #region Propriedades
        public string Modelo { get; set; }

        public int QtdPassageiros { get; set; }

        public DateTime DataCriacao { get; set; }
        #endregion

        #region Validadores
        public override bool IsValid()
        {
            Validar();
            return ValidationResult.IsValid;
            //Todo: Verificar porque esse ValidationResult está retornando sempre como válido, mas a idéia da validação da entidade está implementada
        }

        private void Validar()
        {
            ValidarModelo();
            ValidarQtdPassageiros();
        }

        private void ValidarModelo()
        {
            RuleFor(c => c.Modelo)
                .NotEmpty().WithMessage("O modelo deve ser informado")
                .Length(2, 50).WithMessage("O modelo deve conter entre 2 e 50 caracteres");
        }

        private void ValidarQtdPassageiros()
        {
            RuleFor(c => c.QtdPassageiros)
                .NotNull()
                .WithMessage("É necessário informar a quantidade de passageiros")
                .GreaterThan(0)
                .WithMessage("A quantidade de passageiros deve ser maior que 0");
        }
        #endregion
    }
}