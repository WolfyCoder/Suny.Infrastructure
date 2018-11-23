using System;
using System.Collections.Generic;
using System.Text;

namespace CNSuny.Infrastructure.Uitls
{
    public class AesUtilException : Exception
    {
        public AesUtilException(string message) : base(message) { }
    }
}
