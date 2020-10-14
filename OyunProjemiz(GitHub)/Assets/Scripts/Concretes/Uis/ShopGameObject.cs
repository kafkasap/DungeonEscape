using OyunProjemiz.Abstracts.Combats;
using OyunProjemiz.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OyunProjemiz.Uis
{
    public class ShopGameObject : MonoBehaviour
    {
        [SerializeField] QestionPanel qestionPanel;
        [SerializeField] GameObject shop;
        IHealth _playerHealth;

        private void OnEnable()
        {
           _playerHealth= FindObjectOfType<PlayerController>().GetComponent<IHealth>();
        }

        private void OnDisable()
        {
            _playerHealth = null;
        }

      
        public void BuyLifeClick(int lifeCount)
        {
            qestionPanel.gameObject.SetActive(true);
            qestionPanel.SetLifeCountAndReferance(lifeCount,_playerHealth);
        }

        public void IsActiveShop(bool isActive)
        {
                shop.SetActive(isActive);
        }

        public void FreezeTime()
        {
            Time.timeScale = 0f;
        }

        public void ContuineTime()
        {
            Time.timeScale = 1f;
        }
    }

}
