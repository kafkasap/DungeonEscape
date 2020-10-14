using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OyunProjemiz.Spawners
{
    public class GroundSpawners : MonoBehaviour
    {
        [SerializeField] GameObject[] tile;

        int chooseTile;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Spawner();
        }



        private void Spawner ()
        {
            chooseTile = Random.Range(0, tile.Length);
            Instantiate(tile[chooseTile],this.transform.position,Quaternion.identity);
            Destroy(this.gameObject);

        }

    }


}
