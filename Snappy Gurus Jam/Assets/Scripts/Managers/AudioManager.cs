using System;
using MB.Abstracts;
using UnityEngine;

namespace SB
{
    public class AudioManager : SingletonMonoBehaviour<AudioManager>
    {
        private void Awake()
        {
            ApplySingleton(this);
        }
    }
}