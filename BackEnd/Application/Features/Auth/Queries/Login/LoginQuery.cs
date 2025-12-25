namespace Application.Features.Auth.Queries.Login
{
   public record LoginQuery(string Email, string Password) : IRequest<Result<string>>;
}