namespace ERP.MVC.Application.Models
{
    public class Result<T>
    {
        public T Value { get; private set; }
        public List<string> Errors { get; private set; }
        public bool IsSuccess => Errors == null || !Errors.Any();

        private Result(T value, List<string> errors)
        {
            Value = value;
            Errors = errors;
        }

        public static Result<T> Success(T value) => new Result<T>(value, null);
        public static Result<T> Failure(List<string> errors) => new Result<T>(default, errors);
    }
}
