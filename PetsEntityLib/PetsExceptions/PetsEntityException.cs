using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsEntityLib.PetsExceptions
{
    public class PetsEntityException : Exception
    {
        /* It is good practice to have atleast one of the three
         * common constructors in your custom exception class
         * */

        public PetsEntityException()
        {
            //
        }

        public PetsEntityException(string message) : base (message)
        {
            //
        }

        public PetsEntityException(string message, Exception innerException) : base(message, innerException)
        {
            //
        }
    }
}
