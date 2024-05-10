using Currencies.Contracts.ModelDtos.User;
using Currencies.Contracts.Requests;
using MediatR;

namespace Currencies.Api.Functions.User.Queries.GetUser;

public record GetUserInformationQuery(GetUserRequest request) : IRequest<UserDto>;