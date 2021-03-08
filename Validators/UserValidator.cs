using api.Validators.Interfaces;
using api.Models;
using System;

namespace api.Validators {
    public class UserValidator : IBaseValidator<User> {
        public bool isValid(User user) {
            // TODO: Verificar se username e password são válidos
            if(user == null || String.IsNullOrWhiteSpace(user.Email) 
                || String.IsNullOrWhiteSpace(user.Password)
            )
                return false;
            return true;
        }
    }
}