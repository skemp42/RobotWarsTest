using RW.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace RW.Service
{
    public interface IRobotMovementValidator
    {
        ValidationResult Validate(string userInput);
    }
}
