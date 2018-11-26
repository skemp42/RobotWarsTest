using System;

namespace RW.Core
{
    public class TypeNotRegisteredException : Exception
    {
        public TypeNotRegisteredException(string message)
            : base(message)
        {
        }
    }
}