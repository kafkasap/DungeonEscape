using OyunProjemiz.Abstracts.Animatons;
using OyunProjemiz.Abstracts.Controllers;
using OyunProjemiz.Abstracts.StatesMachines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OyunProjemiz.StateMachines.EnemyStates
{

    public class Dead : IState
    {
        IMyAnimations _animation;
        IEntityController _controller;
        System.Action _deadCallBack;


        float _currentTime = 0f;
        public Dead(IEntityController controller,IMyAnimations animation,System.Action deadCallBack)
        {
            _animation = animation;
            _controller = controller;
            _deadCallBack = deadCallBack;
        }
        public void OnEnter()
        {
            _animation.DeadAnimation();
            //Dead Voice
            _deadCallBack?.Invoke();
        }

        public void OnExit()
        {
            _currentTime = 0f;
        }

        public void Tick()
        {
            _currentTime += Time.deltaTime;

            if (_currentTime > 1f)
            {
                Object.Destroy(_controller.transform.gameObject);
            }
           
        }

       
    }

}

