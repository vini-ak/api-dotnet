using FluentValidation;
using Manager.Domain.Entities;

namespace Manager.Domain.Validators
{
    public class UserValidator: AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A entidade não pode não ser vazia.")

                .NotNull()
                .WithMessage("A entidade não pode ser nula");

            // Name validation
            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage("O nome não pode ser nulo")

                .NotEmpty()
                .WithMessage("O nome não pode ser vazio")

                .MinimumLength(3)
                .WithMessage("O nome deve ter no mínimo 3 caracteres")

                .MaximumLength(120)
                .WithMessage("O nome deve ter no máximo 120 caracteres");
            
            // Email validation
            RuleFor(x => x.Email)
                .NotNull()
                .WithMessage("O email não pode ser nulo")

                .NotEmpty()
                .WithMessage("O email não pode ser vazio")

                .MinimumLength(10)
                .WithMessage("O email deve ter no mínimo 10 caracteres")

                .MaximumLength(180)
                .WithMessage("O nome deve ter no máximo 180 caracteres")

                .Matches(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$")
                .WithMessage("O email informado não é válido");

            // Password validation
            RuleFor(x => x.Password)
                .NotNull()
                .WithMessage("A senha não pode ser nula")

                .NotEmpty()
                .WithMessage("A senha não pode ser vazia")

                .MinimumLength(8)
                .WithMessage("A senha deve ter no mínimo 8 caracteres")

                .MaximumLength(100)
                .WithMessage("A senha deve ter no máximo 100 caracteres");

            // CPF validation
            RuleFor(x => x.Cpf)
                .NotNull()
                .WithMessage("O CPF não pode ser nulo")

                .NotEmpty()
                .WithMessage("O CPF não pode ser vazio")

                .Length(11)
                .WithMessage("O CPF deve possuir 11 dígitos")

                .Matches(@"^\d{11}")
                .WithMessage("O formato do CPF é inválido");

        }
    }
}