using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OyunProjemiz.Spawners
{
    public class GroundDestroy : MonoBehaviour
    {
        [SerializeField] float _destroyTime = 5f;
        private float _currentDestroyTime = 0f;

        private void Update()
        {
            DestroyGround();
        }

        void DestroyGround()
        {
            _currentDestroyTime += Time.deltaTime;
            if (_currentDestroyTime>=_destroyTime)
            {
                Destroy(this.gameObject);
                _currentDestroyTime = 0f;
            }

        }
    }

}
