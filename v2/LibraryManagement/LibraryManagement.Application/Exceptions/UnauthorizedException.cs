﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Exceptions
{
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException()
            : base("Error de Authorización") { }

        public UnauthorizedException(string message)
            : base(message) { }
    }
}
