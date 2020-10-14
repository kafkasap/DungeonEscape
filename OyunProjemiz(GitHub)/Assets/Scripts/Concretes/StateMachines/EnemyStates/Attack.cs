using OyunProjemiz.Abstracts.Animatons;
using OyunProjemiz.Abstracts.Combats;
using OyunProjemiz.Abstracts.Movements;
using OyunProjemiz.Abstracts.StatesMachines;
using OyunProjemiz.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OyunProjemiz.StateMachines.EnemyStates
{

    public class Attack : IState
    {
        IMyAnimations _animation;
        IAttacker _attacker;
        IHealth _playerHealth;       
        IFlip _flip;
       
        
        System.Func<bool> _isPlayerRightSide;


        float _currentAttackTime;
        float _maxAttackTime;

        public Attack(IHealth playerHealth, IFlip flip,IMyAnimations animation, IAttacker attacker,float maxAttackTime,System.Func<bool> isPlayerRightSide)
        {
            _flip = flip;
            _animation = animation;
            _attacker = attacker;
            _playerHealth = playerHealth;
            _maxAttackTime = maxAttackTime;
            _isPlayerRightSide = isPlayerRightSide;
            
            
        }
        public void OnEnter()
        {
            _currentAttackTime = 0f;
        }

        public void OnExit()
        {
        }

        public void Tick()
        {
            _currentAttackTime += Time.deltaTime;
            if (_currentAttackTime>_maxAttackTime)
            {
                _flip.FlipCharacter(_isPlayerRightSide.Invoke()? 1f : -1f);
                
                _animation.AttackAnimation();
                //Attack Voice
                _attacker.Attack(_playerHealth);
                _currentAttackTime = 0f;
            }

            
        }
    }

}

