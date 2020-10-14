using OyunProjemiz.Abstracts.Animatons;
using OyunProjemiz.Abstracts.Controllers;
using OyunProjemiz.Abstracts.Movements;
using OyunProjemiz.Abstracts.StatesMachines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OyunProjemiz.StateMachines.EnemyStates
{

    public class ChasePlayer : IState
    {
      
        IMover _mover;
        IFlip _flip;
        IMyAnimations _animation;
        System.Func<bool> _isPlayerRightSide;

        public ChasePlayer(IMover mover, IFlip flip, IMyAnimations animation,System.Func<bool> isPlayerRightSide)
        {
            _mover = mover;
            _flip = flip;
            _animation = animation;
            _isPlayerRightSide = isPlayerRightSide;

        }

        public void OnEnter()
        {
            _animation.MoveAnimations(1f); //Animasyonu Oynat
        }

        public void OnExit()
        {
            _animation.MoveAnimations(0f); //Animasyonu Idle yap
        }

        public void Tick()
        {
            if (_isPlayerRightSide.Invoke()) //EnemyController içindeki IsPlayerRightSide Methodunu çalıştırır.
            {
                _mover.Tick(1.5f); 
                _flip.FlipCharacter(1f);
            }
            else
            {
                _mover.Tick(-1.5f);
                _flip.FlipCharacter(-1f);
            }

            
        }
    }

}

