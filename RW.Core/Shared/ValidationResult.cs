namespace RW.Core
{
    public class ValidationResult
    {
        private ValidationResult()
        {
            IsValid = true;
        }

        public ValidationResult(string message)
        {
            IsValid = false;
            ErrorMessage = message;
        }

        public bool IsValid { get; }
        public string ErrorMessage { get; }

        public static ValidationResult Ok()
        {
            return new ValidationResult();
        }

        public static ValidationResult Error(string message)
        {
            return new ValidationResult(message);
        }
    }
}
