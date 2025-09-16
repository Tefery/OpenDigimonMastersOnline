using ODMO.Commons.DTOs.Account;
using MediatR;

namespace ODMO.Application.Separar.Queries;

public record CreateGameAccountQuery(string Username, string Password) : IRequest<AccountDTO>;