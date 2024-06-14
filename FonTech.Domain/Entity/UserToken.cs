using FonTech.Domain.Interfaces;

namespace FonTech.Domain.Entity;

public class UserToken : IEntityId<long>
{
    public long Id { get; set; }
    
    public string RefreshToken { get; set; }
    
    public DateTime RefreshTokenExpiryTime { get; set; }
    
    public User User { get; set; }
    
    public long UserId { get; set; }
}