using System;

namespace POC.Exceptions
{
    public class BoaEntregaException : Exception
    {
        public BoaEntregaException(string mensagem)
           : base(mensagem)
        {
          
        }
    }
}
