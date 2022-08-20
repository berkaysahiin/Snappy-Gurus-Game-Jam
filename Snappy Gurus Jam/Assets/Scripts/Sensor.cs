using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        var pickable = other.gameObject.GetComponent<Pickable>();
        if (pickable == null) return;

        Debug.Log("robot is attacking");
    }
}
