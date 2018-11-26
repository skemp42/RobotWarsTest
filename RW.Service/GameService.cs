using RW.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace RW.Service
{
    public class GameService : IGameService
    {
        private readonly IRobotDirectionService DirectionService;
        private readonly IGameValidator GameValidator;
        private readonly IRobotInstructionService InstructionService;

        public GameService(IRobotDirectionService directionService, IGameValidator gameValidator, IRobotInstructionService instructionService)
        {
            DirectionService = directionService;
            GameValidator = gameValidator;
            InstructionService = instructionService;
        }

        public Robot CreateRobot(string userInput)
        {
            var locationValidationResult = (GameValidator as IRobotPositionValidator).Validate(userInput);

            if (!locationValidationResult.IsValid)
            {
                Console.WriteLine(locationValidationResult.ErrorMessage);
                return null;
            }

            var splitString = userInput.Split(" ");
            var playerDir = DirectionService.GetRobotDirection(splitString[2]);
            var playerX = int.Parse(splitString[0]);
            var playerY = int.Parse(splitString[1]);


            var robot = Robot.Activate(playerX, playerY, playerDir);
            return robot;
        }

        public Robot TriggertRobotMovement(string userInput, Robot robot)
        {
            var movementValidationResult = (GameValidator as IRobotMovementValidator).Validate(userInput);

            if (!movementValidationResult.IsValid)
            {
                Console.WriteLine(movementValidationResult.ErrorMessage);
                return null;
            }

            InstructionService.SetRobot(robot).TriggerMovement(userInput);

            return robot;
        }

        public Arena CreateArena(string userInput)
        {
            var validationResult = (GameValidator as ICreateArenaValidator).Validate(userInput);

            if (!validationResult.IsValid)
            {
                Console.WriteLine(validationResult.ErrorMessage);
                return null;
            }

            var x = int.Parse(userInput.Split(" ")[0]);
            var y = int.Parse(userInput.Split(" ")[1]);

            return Arena.Create(x, y);
        }

    }
}
