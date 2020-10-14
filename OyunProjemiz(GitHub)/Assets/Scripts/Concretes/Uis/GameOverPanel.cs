using OyunProjemiz.Enums;
using OyunProjemiz.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OyunProjemiz.Uis
{
    public class GameOverPanel : MonoBehaviour
    {
       public void TryAgainButton()
        {
            Time.timeScale = 1f;

            GameManager.Instance.SplashScreen(SceneTypeEnum.Game);
        }

        public void OverQuitButton()
        {
            Time.timeScale = 1f;

            GameManager.Instance.SplashScreen(SceneTypeEnum.Menu);

        }
    }

}
