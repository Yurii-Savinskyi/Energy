using System;

namespace Energy.Common.Models.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException()
        {

        }

        public NotFoundException(string message)
            : base(message)
        {

        }
    }
}