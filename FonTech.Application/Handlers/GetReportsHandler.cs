using FonTech.Application.Queries;
using FonTech.Domain.Dto.Report;
using FonTech.Domain.Entity;
using FonTech.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FonTech.Application.Handlers;

public class GetReportsHandler(IBaseRepository<Report> reportRepository) : IRequestHandler<GetReportsQuery, ReportDto[]>
{
    public async Task<ReportDto[]> Handle(GetReportsQuery request, CancellationToken cancellationToken)
    {
        return await reportRepository.GetAll()
            .Where(x => x.UserId == request.UserId)
            .Select(x => new ReportDto(x.Id, x.Name, x.Description, x.CreatedAt.ToLongDateString()))
            .ToArrayAsync(cancellationToken);
    }
}