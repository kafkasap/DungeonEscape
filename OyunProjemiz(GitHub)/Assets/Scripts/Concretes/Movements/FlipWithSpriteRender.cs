using OyunProjemiz.Abstracts.Movements;
using OyunProjemiz.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OyunProjemiz.Movements
{
    public class FlipWithSpriteRender : IFlip
    {
        SpriteRenderer _spriteRenderer;

        public FlipWithSpriteRender(PlayerController player)
        {
            _spriteRenderer = player.GetComponent<SpriteRenderer>();

        }


        public void FlipCharacter(float direction)
        {
            if (direction == 0f) return;

            if(direction < 0f)
            {
                _spriteRenderer.flipX = true;
            }
            else
            {
                _spriteRenderer.flipX = false;
            }

        }
    }

}
