using OyunProjemiz.Abstracts.Combats;
using OyunProjemiz.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace OyunProjemiz.Uis
{
    public class DisplayHealth : MonoBehaviour
    {
        Image _healthImage;
        IHealth _health;
        private void Awake()
        {
            _healthImage = GetComponent<Image>();

        }

        private void OnEnable()
        {
            _health = FindObjectOfType<PlayerController>().GetComponent<IHealth>();
            _health.OnHealthChanged += HandleHealthChanged;
        }


        private void OnDisable()
        {
            _health.OnHealthChanged -= HandleHealthChanged;
            _healthImage.fillAmount = 1f;
        }
        private void HandleHealthChanged(int currentHealth, int maxHealth)
        {
            float result = (float)currentHealth / (float)maxHealth;
            _healthImage.fillAmount = result;
        }



    }

}
