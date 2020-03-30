using Callhub.Application.Interfaces;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Callhub.Application.Services
{
    public class HashService : IHashService
    {
        private readonly string Salt = "5cbefb23-da96-4122-b07e-ffdb786eb31b";

        public string Decode(string Value)
        {
            throw new NotImplementedException();
        }

        public string Encode(string Value)
        {
            var valueBytes = KeyDerivation.Pbkdf2(
                password: Value,
                salt: Encoding.ASCII.GetBytes(this.Salt),
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8
                );

            return Convert.ToBase64String(valueBytes);
        }

        public bool Validate(string value, string hash) => (this.Encode(value) == hash);
    }
}
