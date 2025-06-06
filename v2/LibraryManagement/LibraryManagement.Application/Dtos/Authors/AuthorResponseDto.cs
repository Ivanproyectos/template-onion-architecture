﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Application.Dtos.Books;

namespace LibraryManagement.Application.Dtos.Author
{
    public record struct AuthorResponseDto(
        int Id,
        string Name,
        string Nationality,
        List<BookResponseDto> books
    ) { }
}
