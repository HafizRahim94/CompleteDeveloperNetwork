﻿namespace etiqatest.Application.Common.Interfaces
{
    public interface IPasswordHasher
    {
        bool VerifyPassword(string password, string hashedPassword, string saltString);
    }
}
