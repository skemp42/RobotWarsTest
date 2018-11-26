using System;

namespace RW.Core
{
    public class NewMoveEventArgs:EventArgs
    {
        public NewMoveEventArgs(int newXPosition, int newYPosition)
        {
            NewXPosition = newXPosition;
            NewYPosition = newYPosition;
    }
        public int NewXPosition { get; set; }
        public int NewYPosition { get; set; }
        public bool Cancelled { get; set; }
    }
}
