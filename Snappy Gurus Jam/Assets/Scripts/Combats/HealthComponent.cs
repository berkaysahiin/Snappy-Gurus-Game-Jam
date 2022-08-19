using System;
using UnityEngine;

namespace SB
{
    public class HealthComponent : MonoBehaviour, IHealth
    {
        [SerializeField] private float currentHealth;
        public bool IsDead => currentHealth <= 0;
        public float CurrentHealth => currentHealth;

        public HealthComponent(float currentHealth)
        {
            this.currentHealth = currentHealth;
        }

        public void TakeDamage(float damageCount)
        {
            if (IsDead) return;
            if (!IsDead) currentHealth -= damageCount;
        }
    }
}