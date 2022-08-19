using System;
using System.Collections.Generic;
using UnityEngine;

namespace SB
{
    public interface IDecision
    {
        Action CameraCatchCondition(bool condition);
        Action RunCondition(bool condition);
        
        public List<Action> PlayerCatchConditions { get; set; }
    }
}