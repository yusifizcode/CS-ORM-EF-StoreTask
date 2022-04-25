using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_ORM_EF.Data.Exceptions
{
    internal class NotFoundException:Exception
    {
        public NotFoundException(string message):base(message)
        {

        }
    }
}
