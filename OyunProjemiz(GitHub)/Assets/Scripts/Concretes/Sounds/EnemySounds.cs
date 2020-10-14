using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OyunProjemiz.Sounds
{
    public class EnemySounds : MonoBehaviour
    {
        [Header("SOUNDS")]

        [SerializeField] AudioClip deadVoice;

        AudioSource _audioSource;
        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void PlayDeadVoice()
        {
            _audioSource.PlayOneShot(deadVoice);
        }
    }

}
