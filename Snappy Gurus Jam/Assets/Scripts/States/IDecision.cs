using System;
using System.Collections.Generic;
using UnityEngine;

namespace SB
{
    public interface IDecision
    {
        Action CameraCatchCondition(bool condition);
        Action PuzzleCondition(bool condition);
        Action SensorDetectionCondition(bool condition);
        
        public List<Action> PlayerCatchConditions { get; set; }
    }
}