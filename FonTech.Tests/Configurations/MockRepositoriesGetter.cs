using FonTech.Domain.Entity;
using FonTech.Domain.Interfaces.Repositories;
using MockQueryable.Moq;
using Moq;

namespace FonTech.Tests.Configurations;

public static class MockRepositoriesGetter
{
    public static Mock<IBaseRepository<Report>> GetMockReportRepository()
    {
        var mock = new Mock<IBaseRepository<Report>>();
        
        var reports = GetReports().BuildMockDbSet();
        mock.Setup(u => u.GetAll()).Returns(()=> reports.Object);
        return mock;
    }
    
    public static Mock<IBaseRepository<User>> GetMockUserRepository()
    {
        var mock = new Mock<IBaseRepository<User>>();
        
        var users = GetUsers().BuildMockDbSet();
        mock.Setup(u => u.GetAll()).Returns(()=> users.Object);
        return mock;
    }
    
    public static IQueryable<Report> GetReports()
    {
        return new List<Report>() {
            new Report() {
                Id = 1,
                Name = "Деловой отчет #1",
                Description = "Информации пока нет",
                CreatedAt = DateTime.Now.AddDays(-2),
                UpdatedAt = DateTime.Now.AddDays(-2)
            },
            new Report() {
                Id = 2,
                Name = "Деловой отчет #2",
                Description = "Информации пока нет",
                CreatedAt = DateTime.Now.AddDays(-2),
                UpdatedAt = DateTime.Now.AddDays(-2)
            }
        }.AsQueryable();
    }
    
    public static IQueryable<User> GetUsers()
    {
        return new List<User>() {
            new User() {
                Id = 1,
                Login = "ITHomester",
                Password = "dasdKAJSkdqwej4ej#",
                CreatedAt = DateTime.Now.AddDays(-2),
                UpdatedAt = DateTime.Now.AddDays(-2)
            },
            new User() {
                Id = 2,
                Login = "Basne",
                Password = "daskdak@K#K@",
                CreatedAt = DateTime.Now.AddDays(-2),
                UpdatedAt = DateTime.Now.AddDays(-2)
            }
        }.AsQueryable();
    }
}