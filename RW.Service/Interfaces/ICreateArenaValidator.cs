using RW.Core;

namespace RW.Service
{
    public interface ICreateArenaValidator
    {
       ValidationResult Validate(string userInput);
    }
}
