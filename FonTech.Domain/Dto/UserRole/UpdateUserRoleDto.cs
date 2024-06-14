namespace FonTech.Domain.Dto.UserRole;

public class UpdateUserRoleDto
{
    public string Login { get; set; }
    
    public long FromRoleId { get; set; }
    
    public long ToRoleId { get; set; }
}