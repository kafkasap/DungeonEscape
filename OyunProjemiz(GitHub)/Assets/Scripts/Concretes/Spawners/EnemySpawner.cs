using OyunProjemiz.Abstracts.Controllers;
using OyunProjemiz.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OyunProjemiz.Spawners
{
    public class EnemySpawner : MonoBehaviour
    {
        PlayerController _player;
        [SerializeField] ParticleSystem _spawnParticle;

        [Range(2f,5f)]
        [SerializeField] float maxSpawnTime=3f;
        [Range(0.1f,1.99f)]
        [SerializeField] float minSpawnTime = 1f;

        [SerializeField] EnemyController[] enemy;

        float _currentSpawnTime;
        float _timeBoundary;
        int _chooseEnemy;

       
        private void Start()
        {
            ResetTimes();
        }
        private void Update()
        {
            

            _currentSpawnTime += Time.deltaTime;
            if (_currentSpawnTime > _timeBoundary)
            {
                Spawn();
                ResetTimes();

            }
        }
        private void Spawn()
        {
            _chooseEnemy = Random.Range(0, enemy.Length);
            Instantiate(enemy[_chooseEnemy],transform.position,Quaternion.identity);
            Instantiate(_spawnParticle, transform.position, Quaternion.identity);

        }
        private void ResetTimes()
        {
            _currentSpawnTime = 0f;
            _timeBoundary = Random.Range(minSpawnTime, maxSpawnTime);
        }

    }

}
