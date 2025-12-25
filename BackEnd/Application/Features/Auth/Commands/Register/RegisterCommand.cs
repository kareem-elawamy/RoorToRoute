namespace Application.Features.Auth.Commands.Register
{
    public record RegisterCommand(
        string FullName,
        string UserName,
        string Email,
        string Password,
        UserType UserType, // Farmer, Merchant...
        string PhoneNumber
    ) : IRequest<Result<Guid>>;
}