namespace Application.Features.Auth.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Result<Guid>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public RegisterCommandHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<Result<Guid>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            // 1. Check if user exists (Optional validation)
            var existingUser = await _userManager.FindByEmailAsync(request.Email);
            if (existingUser is not null)
            {
                return Result.Failure<Guid>(new Error("Auth.EmailExists", "Email is already in use."));
            }

            // 2. Create User Entity
            var user = new ApplicationUser
            {
                FullName = request.FullName,
                Email = request.Email,
                UserName = request.UserName,
                UserType = request.UserType,
                PhoneNumber = request.PhoneNumber
            };

            // 3. Save to DB using Identity
            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                // تجميع أخطاء Identity وتحويلها للـ Error بتاعنا
                var errorMsg = string.Join(", ", result.Errors.Select(e => e.Description));
                return Result.Failure<Guid>(new Error("Auth.RegistrationFailed", errorMsg));
            }

            // 4. Return Success with the new User ID
            return Result.Success(user.Id);
        }
    }
}