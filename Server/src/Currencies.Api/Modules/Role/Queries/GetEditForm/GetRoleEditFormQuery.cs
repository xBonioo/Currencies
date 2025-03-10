﻿using Currencies.Contracts.Helpers.Forms;
using MediatR;

namespace Currencies.Api.Modules.Role.Queries.GetEditForm;

public record GetRoleEditFormQuery(int id) : IRequest<RoleEditForm>;