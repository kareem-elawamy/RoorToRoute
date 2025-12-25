namespace Application.Features.Auth.Queries.Login
{
   public class LoginQueryHandler : IRequestHandler<LoginQuery, Result<string>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        // هنا المفروض نحقن ITokenService عشان نولد توكن حقيقي
        // بس للتبسيط دلوقتي هنرجع نص ثابت

        public LoginQueryHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Result<string>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            // 1. البحث عن المستخدم
            var user = await _userManager.FindByEmailAsync(request.Email);
            
            if (user is null)
            {
                // لاحظ إننا بنستخدم نفس نمط الخطأ الموحد
                return Result.Failure<string>(new Error("Auth.InvalidCredentials", "Invalid email or password."));
            }

            // 2. التحقق من كلمة المرور
            var isPasswordValid = await _userManager.CheckPasswordAsync(user, request.Password);

            if (!isPasswordValid)
            {
                // نفس الرسالة عشان الأمان (منعرفش المهاجم الغلط فين بالظبط)
                return Result.Failure<string>(new Error("Auth.InvalidCredentials", "Invalid email or password."));
            }

            // 3. (محاكاة) توليد التوكن
            // في الحقيقة هنا بننادي _tokenService.CreateToken(user);
            string fakeToken = $"eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9... (Token for {user.FullName})";

            // 4. إرجاع النجاح
            return Result.Success(fakeToken);
        }
    }
}