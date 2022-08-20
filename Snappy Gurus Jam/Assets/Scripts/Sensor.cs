using System;
using System.Collections;
using System.Collections.Generic;
using SB;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    private NPCController _npc;

    private void Awake()
    {
        _npc = FindObjectOfType<NPCController>();
    }

    private void OnTriggerStay(Collider other)
    {
        var pickable = other.gameObject.GetComponent<Pickable>();
        if (pickable == null) return;
        _npc.CatchCondition(1);
    }
}
