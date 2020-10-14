using OyunProjemiz.Abstracts.Controllers;
using OyunProjemiz.Abstracts.Movements;
using OyunProjemiz.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OyunProjemiz.Movements
{
    public class FlipWithTranform : IFlip
    {
        IEntityController _entity;
        public FlipWithTranform(IEntityController entity)
        {
            _entity = entity;
        }
     
        public void FlipCharacter(float direction)
        {
            if (direction == 0) return;

            float mathValue = Mathf.Sign(direction);

            if(mathValue != _entity.transform.localScale.x)
            {
                _entity.transform.localScale = new Vector2(mathValue, 1f);
            }
        }
    }
}

