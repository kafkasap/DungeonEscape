using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OyunProjemiz.Abstracts.Animatons
{
    
    public interface IMyAnimations
    {
        
        void MoveAnimations(float moveSpeed);
        void JumpAnimation(bool isJump);

        void AttackAnimation();
        void TakeHitAnimation();
        void DeadAnimation();

    }

}
