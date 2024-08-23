using FonTech.Domain.Entity;
using MediatR;

namespace FonTech.Application.Commands;

public record UpdateReportCommand(string Name, string Description, Report Report) : IRequest;