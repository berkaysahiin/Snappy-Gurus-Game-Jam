using System;
using System.Collections;
using System.Collections.Generic;
using SB;
using SG;
using UnityEngine;
using UnityEngine.AI;
using Object = UnityEngine.Object;

public class NPCDecisionStates : IDecision
{
    private NavMeshAgent _navMesh;
    private PlayerCharacterController _player;

    public List<Action> PlayerCatchConditions { get; set; }

    public NPCDecisionStates(NavMeshAgent navMesh, PlayerCharacterController player)
    {
        _player = player;
        _navMesh = navMesh;
        PlayerCatchConditions = new List<Action>
        {
            CameraCatchCondition(true),
            SensorDetectionCondition(true),
            PuzzleCondition(true)
        };
    }
    
    public Action CameraCatchCondition(bool condition)
    {
        if (condition)
        {
            return KillPlayer();
        }
        return null;
    }

    public Action SensorDetectionCondition(bool condition)
    {
        if (condition)
        {
            return KillPlayer();
        }
        return null;
    }

    public Action PuzzleCondition(bool condition)
    {
        if (condition)
        {
            return KillPlayer();
        }
        return null;
    }

    private Action KillPlayer()
    {
        return MoveToPlayer;
    }

    private void MoveToPlayer()
    {
        _player.Health.TakeDamage(1000); // direct kill
        
        _player.PlayerMovement.CanMove = false;
        
        _player.ArmTarget.transform.position = Vector3.Lerp(_player.ArmTarget.transform.position,
            _player.ArmTarget.transform.forward + new Vector3(0, 5, 2), Time.deltaTime);
       
        _navMesh.SetDestination(_player.transform.position);
    }
}