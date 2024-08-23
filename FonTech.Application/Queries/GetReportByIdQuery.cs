using FonTech.Domain.Dto.Report;
using MediatR;

namespace FonTech.Application.Queries;

public class GetReportByIdQuery(long userId) : IRequest<ReportDto?>
{
    public long UserId { get; set; } = userId;
}