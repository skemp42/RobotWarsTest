using System;
using System.Collections.Generic;
using System.Text;

namespace RW.Core
{
    public sealed class Arena
    {
        List<Robot> RobotsInPlay;
        private Arena(int x, int y)
        {
            XLimit = x;
            YLimit = y;
            RobotsInPlay = new List<Robot>();
        }


        public IReadOnlyCollection<Robot> Robots => RobotsInPlay;
        public int XLimit { get; }
        public int YLimit { get; }

        public static Arena Create(int x, int y)
        {
            return new Arena(x, y);
        }

        public void AddRobot(Robot robot)
        {
            ValidateRobot(robot.XPosition, robot.YPosition);
            robot.OnMove += Robot_OnMove;
            RobotsInPlay.Add(robot);
        }

        private void Robot_OnMove(object sender, NewMoveEventArgs e)
        {
            try
            {
                ValidateRobot(e.NewXPosition, e.NewYPosition);
            }
            catch
            {
                e.Cancelled = true;
            }
        }

        public void ValidateRobot(int xPosition, int yPosition)
        {
            if (XLimit < xPosition || YLimit < yPosition || xPosition < 0 || yPosition < 0)
            {
                throw new InvalidOperationException("Robot position invalid. Out of bounds.");
            }

            //Could extend to validate against other robots. 
        }
    }
}
