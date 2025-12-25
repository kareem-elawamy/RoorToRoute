using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Common
{
    public class Result<TValue> : Result
    {
        private readonly TValue? _value;
        protected internal Result(TValue? value, bool isSuccess, Error error)
            : base(isSuccess, error)
        {
            _value = value;
        }

        public TValue Value => IsSuccess
                    ? _value!
                    : throw new InvalidOperationException("The value of a failure result can not be accessed.");

        public static Result<TValue> Success(TValue value) => new(value, true, Error.None);

        public new static Result<TValue> Failure(Error error) => new(default, false, error);
    }
}