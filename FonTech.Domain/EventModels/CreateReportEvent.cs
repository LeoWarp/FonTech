namespace FonTech.Domain.EventModels;

public class CreateReportEvent
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string DateCreated { get; set; }
}