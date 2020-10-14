using OyunProjemiz.Abstracts.Animatons;
using OyunProjemiz.Abstracts.Combats;
using OyunProjemiz.Abstracts.StatesMachines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OyunProjemiz.StateMachines.EnemyStates
{

    public class TakeHit : IState
    {
        IMyAnimations _animation;

        float _maxDelayTime = 0.1f;
        float _currentDelayTime = 0f;

        public bool IsTakeHit { get;private set; }

        public TakeHit(IHealth health,IMyAnimations animation)
        {
            _animation = animation;
            health.OnHealthChanged += (currentHealth,maxHealth)=> OnEnter();
        }

        public void OnEnter()
        {
            IsTakeHit = true;
        }

        public void OnExit()
        {
            _currentDelayTime = 0f;
        }

        public void Tick()
        {
            _currentDelayTime += Time.deltaTime;
            if (_currentDelayTime>_maxDelayTime && IsTakeHit)
            {
                _animation.TakeHitAnimation();
                //Take Hit Voice
                
                IsTakeHit = false;
            }

        }
    }

}


