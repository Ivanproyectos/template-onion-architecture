using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.autor.Application.Models.Constants
{
    public class StatusCodesConst
    {
        public const int Status400BadRequest = 400;
        public const string Status400BadRequestType =
            "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1";

        public const int Status500InternalServerError = 500;
        public const string Status500InternalServerErrorType =
            "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1";

        public const int Status401Unauthorized = 401;
        public const string Status401UnauthorizedType =
            "https://datatracker.ietf.org/doc/html/rfc7235#section-3.1";
    }
}
