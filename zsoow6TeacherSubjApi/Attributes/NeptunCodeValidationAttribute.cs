using System.ComponentModel.DataAnnotations;

namespace zsoow6TeacherSubjApi.Attributes
{
    public class NeptunCodeValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            if (value is string trackNumber)
            {
                var s = value as string;
                bool result = s.All(Char.IsLetterOrDigit);
                if (s.Length == 6 && result)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("Wrong tracknumber!");
                }
            }
            else
            {
                return new ValidationResult("Wrong tracknumber!");
            }
        }
    }
}
