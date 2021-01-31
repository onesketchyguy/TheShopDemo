using System.Collections;
using UnityEngine;

namespace World.Effects
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundEffectLooper : MonoBehaviour
    {
        public AudioClip[] clips;

        [Tooltip("Random wait time between sounds.")]
        public float randomWaitLength = 1;

        [Tooltip("Constant wait time between sounds.")]
        public float constantWaitLength = 0.1f;

        private AudioSource audioSource;

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
            StartCoroutine(PlaySounds());
        }

        private IEnumerator PlaySounds()
        {
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(0, randomWaitLength));
                yield return new WaitForSeconds(constantWaitLength);

                int index = Random.Range(0, clips.Length);

                audioSource.PlayOneShot(clips[index]);
            }
        }
    }
}