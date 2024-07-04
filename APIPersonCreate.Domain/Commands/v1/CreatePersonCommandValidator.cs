using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;


namespace APIPersonCreate.Domain.Commands.v1
{
    public class CreatePersonCommandValidator : AbstractValidator<CreatePersonCommand>
    {
        public CreatePersonCommandValidator() 
        {
            RuleFor(Created =>Created.CPF)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("CPF is required")
                .MinimumLength(11).WithMessage("CPF must be 11 characters")
                .MaximumLength(11).WithMessage("CPF must be 11 characters")
                .Must(BeAValidCPF).WithMessage("Invalid CPF");
        }
        private bool BeAValidCPF(string cpf)
        {
            //validate cpf
            int sum = 0;
            for (int i = 0; i < 9; i++)
                sum += (10 - i) * int.Parse(cpf[i].ToString());

            int rest = sum % 11;

            int digit1 = rest < 2 ? 0 : 11 - rest;

            if(digit1 != int.Parse(cpf[9].ToString()))
                return false;

            sum = 0;
            for (int i = 0; i < 10; i++)
                sum += (11 - i) * int.Parse(cpf[i].ToString());

            rest = sum % 11;

            int digit2 = rest < 2 ? 0 : 11 - rest;
            if(digit2 != int.Parse(cpf[10].ToString()))
                return false;

            return true;
        }
    }
}
