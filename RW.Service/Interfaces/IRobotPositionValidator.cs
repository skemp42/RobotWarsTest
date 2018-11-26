using RW.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace RW.Service
{
    public interface IRobotPositionValidator
    {
        ValidationResult Validate(string userInput);
    }
}
