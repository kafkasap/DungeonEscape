using System;
using System.Collections;
using System.Collections.Generic;
using OyunProjemiz.Abstracts.Animatons;
using OyunProjemiz.Abstracts.Combats;
using OyunProjemiz.Abstracts.Controllers;
using OyunProjemiz.Abstracts.Inputs;
using OyunProjemiz.Abstracts.Movements;
using OyunProjemiz.Animations;
using OyunProjemiz.Inputs;
using OyunProjemiz.Managers;
using OyunProjemiz.Movements;
using OyunProjemiz.Uis;
using UnityEngine;

namespace OyunProjemiz.Controllers
{
    public class PlayerController : MonoBehaviour,IEntityController 
    {
        [SerializeField] float movespeed = 3f;
        

        IPlayerInput _input;
        IMover _mover;
        IMyAnimations _animation;
        IFlip _flip;
        Jump _jump;
        IOnground _onGround;
        IHealth _health;
        AudioSource _audioSource;

        float _horizontal;
        bool _isJump = false;
        //bool _isAttack = false;
      
       

        private void Awake()
        {
            _input = new PcInput();          //!!!SpawnerMove değiştirmeyi unutma!!!
            _mover = new Mover(this,movespeed);
            _animation = new CharacterAnimation(GetComponent<Animator>());
            _flip = new FlipWithTranform(this);
            _jump = new Jump(GetComponent<Rigidbody2D>());
            _onGround = GetComponent<IOnground>();
            _health = GetComponent<IHealth>();
            _audioSource = GetComponent<AudioSource>();
        }

        private void OnEnable()
        {
            _health.OnHealthChanged += (currentHealth, maxHealth) => _animation.TakeHitAnimation();

            

            _health.OnDead += GameManager.Instance.ScoreSave;
            
        }



        



        private void Start()
        {
            GameOverObject gameOverObject = FindObjectOfType<GameOverObject>();
            gameOverObject.SetPlayerHealth(_health);
        }

        private void Update()
        {
            
            if (_health.IsDead)
            {               
                return;
            }
                


            
            


            _horizontal = _input.Horizontal;

            if (_input.AttackButtonDown)
            {
                _animation.AttackAnimation();
                
                return;
            }

            if (_input.JumpButtonDown && _onGround.IsGround)
            {
                _isJump = true;
            }


            _animation.JumpAnimation(!_onGround.IsGround);
            _animation.MoveAnimations(_horizontal);

        }
        private void FixedUpdate()
        {
            _flip.FlipCharacter(_horizontal);
            _mover.Tick(_horizontal);

            if (_isJump && _onGround.IsGround)
            {
                _jump.TickWithFixedUpdate();
                _isJump = false;

            }

        }

        private void TakeHitAnim()
        {
            _animation.TakeHitAnimation();
            
        }
        private void DeadAnim()
        {
            _animation.DeadAnimation();
        }


        
    }
}

