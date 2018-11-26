using System;
using System.Collections.Generic;
using System.Text;

namespace RW.Core
{
    public partial class Robot
    {
        public int XPosition { get; private set; }
        public int YPosition { get; private set; }
        public RobotDirection Direction { get; set; }

        public event EventHandler<NewMoveEventArgs> OnMove;

        private Robot(int _xPosition, int _yPosition, RobotDirection _direction)
        {
            XPosition = _xPosition;
            YPosition = _yPosition;
            Direction = _direction;
        }

        public static Robot Activate(int _xPosition, int _yPosition, RobotDirection _direction)
        {
            return new Robot(_xPosition, _yPosition, _direction);
        }

        public override string ToString()
        {
            return $"{XPosition} {YPosition} {Direction}";
        }


        public void MoveNorth()
        {
            var e = new NewMoveEventArgs(XPosition, YPosition + 1);
            OnMove(this, e);
            if (e.Cancelled) return;
            YPosition += 1;
        }

        public void MoveSouth()
        {
            var e = new NewMoveEventArgs(XPosition, YPosition - 1);
            OnMove(this, e);
            if (e.Cancelled) return;
            this.YPosition -= 1;
        }

        public void MoveWest()
        {
            var e = new NewMoveEventArgs(XPosition - 1, YPosition);
            OnMove(this, e);
            if (e.Cancelled) return;
            this.XPosition -= 1;
        }

        public void MoveEast()
        { 
            var e = new NewMoveEventArgs(XPosition + 1, YPosition);
            OnMove(this, e);
            if (e.Cancelled) return;
            this.XPosition += 1;
        }
    }
}
