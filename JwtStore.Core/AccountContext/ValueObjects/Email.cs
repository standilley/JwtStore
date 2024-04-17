using JwtStore.Core.SharedContext.Extensions;
using JwtStore.Core.SharedContext.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JwtStore.Core.AccountContext.ValueObjects
{
    public partial class Email : ValueObject
    {
        private const string Pattern
            = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        public Email(string address)
        {
            if(string.IsNullOrEmpty(address))
                throw new ArgumentNullException("E-mail inválido");

            Address = address.Trim().ToLower();

            if (Address.Length < 5)
                throw new Exception("E-mail inválido");

            if (!EmailRegex().IsMatch(Address))
                throw new Exception("E-mail inválido");
        }
        public string Address { get;}
        public string Hash => Address.ToBase64();
        public Verification Verification { get; private set; } = new();
        public void ResetVerification()
            => Verification = new Verification();

        public static implicit operator string(Email email)
            => email.ToString();

        public static implicit operator Email(string address)
            => new Email(address);

        public override string ToString()
            => Address;        
        [GeneratedRegex(Pattern)]
        private static partial Regex EmailRegex();
    }
}


