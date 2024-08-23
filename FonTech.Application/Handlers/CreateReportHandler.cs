using FonTech.Application.Commands;
using FonTech.Domain.Entity;
using FonTech.Domain.Interfaces.Repositories;
using MediatR;

namespace FonTech.Application.Handlers;

public class CreateReportHandler(IBaseRepository<Report> reportRepository) : IRequestHandler<CreateReportCommand>
{
    public async Task Handle(CreateReportCommand request, CancellationToken cancellationToken)
    {
        var report = new Report()
        {
            Name = request.Name,
            Description = request.Description,
            UserId = request.UserId,
        };
        await reportRepository.CreateAsync(report);
        await reportRepository.SaveChangesAsync();
    }
}