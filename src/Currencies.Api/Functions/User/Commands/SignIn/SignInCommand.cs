﻿using MediatR;
using Currencies.Contracts.ModelDtos.Account;
using Currencies.Contracts.ResponseModels;

namespace Currencies.Api.Functions.User.Commands.SignIn;

public record SignInCommand(SignInDto dto) : IRequest<RefreshTokenResponse?>;