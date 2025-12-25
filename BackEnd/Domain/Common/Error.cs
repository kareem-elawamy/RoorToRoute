using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Common
{
    public sealed record Error(string Code, string Description)
    {
        // قيمة فارغة تمثل "لا يوجد خطأ"
        public static readonly Error None = new(string.Empty, string.Empty);
        public static readonly Error UnexpectedError = new("Error.Unexpected", "An unexpected error occurred.");
        public static readonly Error NotFound = new("Error.NotFound", "The specified resource was not found.");
        public static readonly Error InvalidOperation = new("Error.InvalidOperation", "The operation is invalid in the current context.");
        public static readonly Error Unauthorized = new("Error.Unauthorized", "The user is not authorized to perform this action.");
        public static readonly Error ValidationFailed = new("Error.ValidationFailed", "One or more validation errors occurred.");
        // أمثلة لأخطاء عامة قد نحتاجها
        public static readonly Error NullValue = new("Error.NullValue", "The specified result value is null.");
        public static readonly Error ConditionNotMet = new("Error.ConditionNotMet", "The specified condition was not met.");
    }
}