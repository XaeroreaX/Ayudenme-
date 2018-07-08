using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CajonLlenoException : Exception 
    {

        private string message;

        public override string Message { get { return message; } }


        public CajonLlenoException(string message)
        {

            this.message = message;

        }

    }
}
