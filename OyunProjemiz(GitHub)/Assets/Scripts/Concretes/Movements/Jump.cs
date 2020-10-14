using OyunProjemiz.Abstracts.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OyunProjemiz.Movements
{
    public class Jump
    {
        float jumpForce = 300f;
        Rigidbody2D _rigidbody;
        public Jump(Rigidbody2D rigidbody)
        {
            _rigidbody = rigidbody;

        }

        public void TickWithFixedUpdate()
        {
            _rigidbody.velocity = Vector2.zero;

            _rigidbody.AddForce(Vector2.up * jumpForce);

            _rigidbody.velocity = Vector2.zero;

        }

    }
}
