﻿namespace Library.Models.Exceptions;
public class UnAuthorizedException : Exception
{
    public UnAuthorizedException(string msg) : base(msg) { }
}
