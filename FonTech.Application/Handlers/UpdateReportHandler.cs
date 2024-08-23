using FonTech.Application.Commands;
using FonTech.Domain.Entity;
using FonTech.Domain.Interfaces.Repositories;
using MediatR;

namespace FonTech.Application.Handlers;

public class UpdateReportHandler(IBaseRepository<Report> reportRepository) : IRequestHandler<UpdateReportCommand>
{
    public async Task Handle(UpdateReportCommand request, CancellationToken cancellationToken)
    {
        var report = request.Report;
        report.Description = request.Description;
        report.Name = request.Name;
        
        var updatedReport = reportRepository.Update(report);
        await reportRepository.SaveChangesAsync();
    }
}