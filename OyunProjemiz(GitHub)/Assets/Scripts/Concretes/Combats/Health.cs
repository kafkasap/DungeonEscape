using OyunProjemiz.Abstracts.Combats;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OyunProjemiz.Combats
{
    public class Health : MonoBehaviour, IHealth
    {
        

        [SerializeField] int maxHealth = 3;

        [SerializeField]int currentHealth;

        public bool IsDead => currentHealth < 1; //currentHealt 1'den küçük ise IsDead true döner.

        public event System.Action<int,int> OnHealthChanged;
        public event System.Action OnDead;

        AudioSource _audioSource;

        private void Awake()
        {
            currentHealth = maxHealth;
            _audioSource = GetComponent<AudioSource>();
        }
        public void TakeHit(IAttacker attacker)
        {
            if (IsDead) return;

            currentHealth = Mathf.Max(currentHealth -= attacker.Damage, 0);
            OnHealthChanged?.Invoke(currentHealth,maxHealth);
            

            if (IsDead) OnDead?.Invoke();
            
                
                
            
        }
        public void Heal(int lifeCount)
        {
            currentHealth = Mathf.Min(currentHealth += lifeCount, maxHealth);
            OnHealthChanged?.Invoke(currentHealth, maxHealth);
        }
    }

}
