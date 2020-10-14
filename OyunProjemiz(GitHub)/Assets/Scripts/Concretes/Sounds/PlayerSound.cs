using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OyunProjemiz.Sounds
{
    public class PlayerSound : MonoBehaviour
    {
        [Header("SOUNDS")]
        [SerializeField] AudioClip attackVoice;
        [SerializeField] AudioClip deadVoice;
        [SerializeField] AudioClip jumpVoice;
        [SerializeField] AudioClip takeHitVoice;


        AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void PlayAttackVoice()
        {
            _audioSource.PlayOneShot(attackVoice);
        }
        public void PlayTakeHitVoice()
        {
            _audioSource.PlayOneShot(takeHitVoice);
        }

        public void PlayDeadVoice()
        {
            _audioSource.PlayOneShot(deadVoice);
        }
        public void PlayJumpVoice()
        {
            _audioSource.PlayOneShot(jumpVoice);

        }


    }

}

