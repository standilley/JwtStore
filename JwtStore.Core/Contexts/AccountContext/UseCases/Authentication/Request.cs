﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtStore.Core.Contexts.AccountContext.UseCases.Authentication
{
    public record Request(
        string Email,
        string Password
        ): IRequest<Response>;    
}
