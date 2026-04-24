using DemoPD.Domain.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoPD.Persistance.Repositories
{
    public class PasswordHasherRepository : IPasswordHasher
    {
        public string Hash(string password) => BCrypt.Net.BCrypt.HashPassword(password);
        public bool Verify(string password, string passwordHash) => BCrypt.Net.BCrypt.Verify(password, passwordHash);
    }
}
