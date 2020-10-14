using OyunProjemiz.Abstracts.Combats;
using OyunProjemiz.Controllers;
using OyunProjemiz.Managers;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace OyunProjemiz.Uis
{
    public class QestionPanel : MonoBehaviour
    {
        [SerializeField] ResultPanel resultPanel;

        TextMeshProUGUI _messageText;
        int _lifeCount;
        IHealth _playerHealth;


        private void Awake()
        {

            _messageText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();

        }
        private void OnDisable()
        {
            _lifeCount = 0;
            _playerHealth = null;
        }
        public void SetLifeCountAndReferance(int lifeCount,IHealth playerHealth)
        {
            _lifeCount = lifeCount;
            _messageText.text = $"Do You want buy {_lifeCount} life ???";
            _playerHealth = playerHealth;

        }

        public void YesClick()
        {
            resultPanel.gameObject.SetActive(true);
            if (_lifeCount <= GameManager.Instance.Score)
            {
                resultPanel.SetResultMessage($"You have bouth {_lifeCount} life have a good play...");
                GameManager.Instance.DecreaseScore(_lifeCount);
                _playerHealth.Heal(_lifeCount);
            }
            else
            {
                resultPanel.SetResultMessage("You do not have enouth diamond");
            }

            this.gameObject.SetActive(false);
        }
    }

}
