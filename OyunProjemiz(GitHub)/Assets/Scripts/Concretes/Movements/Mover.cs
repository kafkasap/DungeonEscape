using OyunProjemiz.Abstracts.Controllers;
using OyunProjemiz.Abstracts.Movements;
using OyunProjemiz.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OyunProjemiz.Movements
{
    public class Mover : IMover
    {

        IEntityController _controller;
        //float moveSpeed = 5f;
        float _moveSpeed;


        public Mover(IEntityController controller,float moveSpeed)
        {
            _controller = controller;
            _moveSpeed = moveSpeed;
        }

        public void Tick(float horizontal)
        {
            if (horizontal == 0f) return;
            _controller.transform.Translate(Vector2.right * horizontal * Time.deltaTime * _moveSpeed);
        }


    }
}
