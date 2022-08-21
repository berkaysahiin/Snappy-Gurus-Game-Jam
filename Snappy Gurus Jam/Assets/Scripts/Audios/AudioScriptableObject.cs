using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(order = 0, fileName = "AudioScriptable", menuName = "AudioScriptable")]
public class AudioScriptableObject : ScriptableObject
{
    [Header("-----Audio Clip-----")]
    [Space(20)]
    public List<AudioClip> clips;
}
