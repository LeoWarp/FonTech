using MediatR;

namespace FonTech.Application.Commands;

public record CreateReportCommand(string Name, string Description, long UserId) : IRequest;