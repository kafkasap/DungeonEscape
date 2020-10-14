using OyunProjemiz.Abstracts.Animatons;
using OyunProjemiz.Abstracts.Controllers;
using OyunProjemiz.Abstracts.Movements;
using OyunProjemiz.Abstracts.StatesMachines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace OyunProjemiz.StateMachines.EnemyStates
{

    public class Idle : IState
    {
         
        IMover _mover;
        IMyAnimations _animation;
        

        float _maxStandTime; //Beklene süresi.  
        float _currentStandTime=0f;//Kalan bekleme süresi.


        public bool IsIdle { get; private set; }

        public Idle( IMover mover, IMyAnimations animation)
        {
            _mover = mover;
            _animation = animation;           
            _maxStandTime = Random.Range(4f, 10f);
             


        }
        public void OnEnter()
        {
            IsIdle = true; //Idle Giriş.
            _animation.MoveAnimations(0f); //Blend Tree Idle animasyon değeri.
        }

        public void OnExit()
        {
            _maxStandTime = 0f; //Başlangıçta MAX bekleme süresi.
        }

        public void Tick()
        {
            _mover.Tick(0f); //Hareketsiz kalması sağlanıyor.

            _currentStandTime += Time.deltaTime;  

            if (_currentStandTime>_maxStandTime)
            {
                IsIdle = false; //Bekleme süresi biterse IDLE çıkış yap(Stata Machine)

            }

            

        }
    }

}

