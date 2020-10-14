using OyunProjemiz.Abstracts.Animatons;
using OyunProjemiz.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OyunProjemiz.Animations
{
    public class CharacterAnimation:IMyAnimations
    {
        Animator _animator;
        
        public CharacterAnimation(Animator animator)
        {
            _animator = animator;
        }

        public void AttackAnimation()
        {
            
            _animator.SetTrigger("attack");
        }

        public void DeadAnimation()
        {
            _animator.SetTrigger("dead");
        }

        public void JumpAnimation(bool isJump)
        {
            if (_animator.GetBool("isJump") == isJump) return;

            _animator.SetBool("isJump", isJump);

        }

        public void MoveAnimations(float moveSpeed)
        {
            _animator.SetFloat("moveSpeed", Mathf.Abs(moveSpeed)); //MoveSpeed'den gelen değeri "+" işaretli olarak animatora gönder.

        }

        public void TakeHitAnimation()
        {
            _animator.SetTrigger("takeHit");
        }
    }
}

