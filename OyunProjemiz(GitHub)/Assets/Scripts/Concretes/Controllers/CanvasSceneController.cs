using OyunProjemiz.Enums;
using OyunProjemiz.Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OyunProjemiz.Controllers
{
    public class CanvasSceneController : MonoBehaviour
    {

        [SerializeField] SceneTypeEnum _sceneType;
        [SerializeField] GameObject _canvasObject;

        
        private void Start()
        {
            GameManager.Instance.OnSceneChanged += HandeleSceneChanged;
        }


        private void OnDestroy()
        {
            GameManager.Instance.OnSceneChanged -= HandeleSceneChanged;
        }
        private void HandeleSceneChanged(SceneTypeEnum sceneType)
        {
            if (sceneType == this._sceneType)
            {
                _canvasObject.SetActive(true);
            }
            else
            {
                _canvasObject.SetActive(false);//dsadasd
            }
        }

    }

}
