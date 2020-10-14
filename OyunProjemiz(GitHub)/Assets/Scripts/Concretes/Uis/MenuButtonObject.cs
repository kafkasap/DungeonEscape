using OyunProjemiz.Enums;
using OyunProjemiz.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OyunProjemiz.Uis
{
    /// <summary>
    /// Menu Panel icindeki ButtonObjectse ait bir componenttir bu component'in amacı icinde Menu Start ve Quit methodları için yazılmıştır. 
    /// </summary>

    public class MenuButtonObject : MonoBehaviour
    {
        public void StartGame()
        {
            GameManager.Instance.SplashScreen(SceneTypeEnum.Game);
        }
        public void QuitGame()
        {
            GameManager.Instance.QuitGame();
        }
    }

}
