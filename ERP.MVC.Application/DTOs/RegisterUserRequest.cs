using MediatR;

namespace ERP.MVC.Application.DTOs
{
    public class RegisterUserRequest : IRequest<Guid>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public List<Guid> BranchIds { get; set; } = new();
        public List<Guid> RoleIds { get; set; } = new();
    }

    public class RoleDto
    {
        public Guid Id { get; set; }
        public string RoleName { get; set; }
        public List<PermissionDto> Permissions { get; set; } = new();
    }

    public class PermissionDto
    {
        public Guid Id { get; set; }
        public string PermissionName { get; set; }
    }
}
