using Flunt.Notifications;
using Flunt.Validations;
using JwtStore.Core.Contexts.AccountContext.UseCases.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtStore.Core.Contexts.AccountContext.UseCases.Authentication
{
    public static class Specification
    {
        public static Contract<Notification> Ensure(Request request) =>
        new Contract<Notification>()
        .Requires()
        .IsLowerThan(request.Password.Length, 40, "Password", "A senha deve conter menos que 40 caracteres")
        .IsGreaterThan(request.Password.Length, 8, "Password", "A senha deve conter mais que 8 caracteres")
        .IsEmail(request.Email, "Email", "E-mail inválido");
    }
}
