﻿namespace CompressCraft.Application.Abstractions.Authentication;

public interface IPasswordManager
{
    string Secure(string password);
    bool Validate(string password, string passwordHash);
}
