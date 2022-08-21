using System;
using System.Collections;
using System.Collections.Generic;
using SB;
using UnityEngine;
using SG;

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
        GameManager.Instance.LoadNextScene();
    }

}
