using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_ORM_EF.Data.Exceptions
{
    internal class DataIsAlreadyExistsException:Exception
    {
        public DataIsAlreadyExistsException(string message):base(message)
        {

        }
    }
}
