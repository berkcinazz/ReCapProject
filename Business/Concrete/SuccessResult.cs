using Core.Utilities.Results;

namespace Business.Concrete
{
    internal class SuccessResult<T> : IResult
    {
        public bool Success { get; }

        public string Message { get; }
    }
}