using OyunProjemiz.Abstracts.Combats;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace OyunProjemiz.Uis
{
    public class GameOverObject : MonoBehaviour
    {
        [SerializeField] GameObject gameOverPanel;

        IHealth _playerHealth;

        private void OnEnable()
        {
            gameOverPanel.SetActive(false);
        }
    
        public void SetPlayerHealth(IHealth health)
        {
            _playerHealth = health;
            _playerHealth.OnDead += HandleDead;
        }

        private void HandleDead()
        {
            gameOverPanel.SetActive(true);
            Time.timeScale = 0f;
            _playerHealth.OnDead -= HandleDead;
            _playerHealth = null; 
        }
    }


}
