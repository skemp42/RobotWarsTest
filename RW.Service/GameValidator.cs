using RW.Core;
using System.Linq;

namespace RW.Service
{
    public class GameValidator : IGameValidator, ICreateArenaValidator, IRobotPositionValidator, IRobotMovementValidator
    {
        ValidationResult ICreateArenaValidator.Validate(string userInput)
        {
            if (string.IsNullOrEmpty(userInput))
            {
                return ValidationResult.Error("Input cannot be empty.");
            }

            var inputSplit = userInput.Split(" ");

            if (inputSplit.Length < 2)
            {
                return ValidationResult.Error("Input must be two numbers seperated by a space.");
            }

            int x, y;
            var parseY = int.TryParse(inputSplit[0], out x);
            var parseX = int.TryParse(inputSplit[1], out y);

            if (!parseX || !parseY)
            {
                return ValidationResult.Error("Input must be two numbers seperated by a space.");

            }

            if (x < 0 || y < 0)
            {
                return ValidationResult.Error("Arena X & Y cannot be below zero.");
            }

            return ValidationResult.Ok();
        }

        ValidationResult IRobotPositionValidator.Validate(string userInput)
        {
            if (string.IsNullOrEmpty(userInput))
            {
                return ValidationResult.Error("Input cannot be empty.");
            }

            var inputSplit = userInput.Split(" ");

            if (inputSplit.Length < 3)
            {
                return ValidationResult.Error("Input must be two numbers and a direction seperated by a space.");
            }


            int x, y, s;
            var parseY = int.TryParse(inputSplit[0], out x);
            var parseX = int.TryParse(inputSplit[1], out y);
            var parseString = int.TryParse(inputSplit[2], out s);

            if (!parseY || !parseX || parseString)
            {
                return ValidationResult.Error("First two inputs should be a number.");
            }

            //Todo - Get direction service to check its a direction.

            if (x < 0 || y < 0)
            {
                return ValidationResult.Error("Robot X & Y cannot be below zero.");
            }

            return ValidationResult.Ok();
        }

        ValidationResult IRobotMovementValidator.Validate(string userInput)
        {
            var allowedMovements = new char[] { 'L', 'R', 'M' };
            var userInputSplit = userInput.ToUpper().ToCharArray();

            foreach (var value in userInputSplit)
            {
                if (!allowedMovements.Any(c => c == value))
                {
                    return ValidationResult.Error("Illegal character in movement input.");
                }
            }

            return ValidationResult.Ok();
        }
    }
}
