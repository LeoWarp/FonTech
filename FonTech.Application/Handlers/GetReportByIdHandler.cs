using FonTech.Application.Queries;
using FonTech.Domain.Dto.Report;
using FonTech.Domain.Entity;
using FonTech.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FonTech.Application.Handlers;

public class GetReportByIdHandler(IBaseRepository<Report> reportRepository) : IRequestHandler<GetReportByIdQuery, ReportDto?>
{
    public Task<ReportDto?> Handle(GetReportByIdQuery request, CancellationToken cancellationToken)
    {
        var report = reportRepository.GetAll()
            .AsEnumerable()
            .Select(x => new ReportDto(x.Id, x.Name, x.Description, x.CreatedAt.ToLongDateString()))
            .FirstOrDefault(x => x.Id == request.UserId);

        return Task.FromResult(report);
    }
}