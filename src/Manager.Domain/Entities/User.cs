using System;
using System.Collections.Generic;
using Manager.Domain.Validators;

namespace Manager.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; private set; }

        public string Email { get; private set; }

        public string Password { get; private set; }

        public string Cpf { get; private set; }

        // O construtor abaixo é usado apenas pelo Entity Framework.
        protected User(){}

        public User(string name, string email, string password, string cpf)
        {
            Name = name;
            Email = email;
            Password = password;
            Cpf = cpf;
            _errors = new List<string>();
        }

        // Behaviours
        public void ChangeName(string name)
        {
            Name = name;
            Validate();
        }

        public void ChangeEmail(string email)
        {
            Email = email;
            Validate();
        }

        public void ChangePassword(string password)
        {
            Password = password;
            Validate();
        }

        // Self-validation
        public override bool Validate()
        {
            var validator = new UserValidator();
            var validation = validator.Validate(this);

            if(!validation.IsValid) {
                foreach (var error in validation.Errors)
                {
                    _errors.Add(error.ErrorMessage);
                }

                throw new Exception("Alguns campos estão inválidos, por favor corriga-os." + _errors[0]);
            }

            return true;
        }
    }
}