using RW.Core;
using RW.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RW.Service
{

    public class RobotWarService
    {
        public int NumberOfRobots { get; private set; } = 2;

        private Arena Arena;
        readonly IGameService GameService;

        public RobotWarService(IGameService gameService)
        {
            GameService = gameService;
        }

        public RobotWarService SetNumberOfRobots(int number)
        {
            NumberOfRobots = number;
            return this;
        }

        public void StartGame()
        {
            Console.WriteLine("Welcome to Robot Wars! Please enter the size of the arena...");

            var userInput = Console.ReadLine();
            Arena = GameService.CreateArena(userInput);

            if (Arena == null)
            {
                RestartGame();
            }

            for (var i = 0; i < NumberOfRobots; i++)
            {
                TriggerNewRobotSequence();
            }

            EndGame();
        }


        private void EndGame()
        {
            Console.WriteLine();
            Console.WriteLine("--- Ending Positions ---");

            foreach (var robot in Arena.Robots)
            {
                Console.WriteLine(robot.ToString());
            }

            RestartGame();
        }

        private void RestartGame()
        {
            Console.WriteLine("Would you like to play again? Yes: Y No: N");

            var startAgain = Console.ReadLine();

            if (startAgain.ToUpper() == "Y")
            {
                Console.Clear();
                StartGame();
            }
        }

        public void TriggerNewRobotSequence()
        {
            string userInput;
            Console.WriteLine("Set the location of your robot...");


            userInput = Console.ReadLine();
            var robot = GameService.CreateRobot(userInput);

            if (robot == null)
            {
                RestartGame();
            }

            Arena.AddRobot(robot);

            Console.WriteLine("Please input movement.");

            userInput = Console.ReadLine();
            GameService.TriggertRobotMovement(userInput, robot);

            if (robot == null)
            {
                RestartGame();
            }

            Console.WriteLine(robot.ToString());
        }



    }
}
