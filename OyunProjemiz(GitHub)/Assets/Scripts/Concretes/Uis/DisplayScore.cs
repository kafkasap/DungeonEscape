using OyunProjemiz.Managers;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace OyunProjemiz.Uis
{
    public class DisplayScore : MonoBehaviour
    {
        TextMeshProUGUI _scoreText;
        private void Awake()
        {
            _scoreText = GetComponent<TextMeshProUGUI>();
            _scoreText.text = GameManager.Instance.Score.ToString();
        }
       
        private void OnEnable()
        {
            GameManager.Instance.OnScoreChanged += HandleScoreChange;
        }


        private void OnDisable()
        {
            GameManager.Instance.OnScoreChanged -= HandleScoreChange;
        }

        private void HandleScoreChange(int score)
        {
            _scoreText.text = score.ToString();
        }

    }


}
