using UnityEngine;

namespace Characters
{
    public class CharacterFootsteps : MonoBehaviour
    {
        [SerializeField]
        private CharacterAnimator animator;

        private float lastStep = 0;

        [SerializeField]
        private float timeBetweenSteps = 0.25f;

        public AudioClip[] stepSounds;

        public AudioSource audioSource;

        // Update is called once per frame
        private void Update()
        {
            if (animator.GetMoveSpeed() > Mathf.Epsilon)
            {
                if (lastStep <= 0)
                {
                    PlaySound();
                    lastStep = timeBetweenSteps;
                }
                else lastStep -= Time.deltaTime;
            }
            else if (lastStep > 0)
            {
                PlaySound();
                lastStep = 0;
            }
        }

        private void PlaySound()
        {
            var index = Random.Range(0, stepSounds.Length);

            audioSource.PlayOneShot(stepSounds[index]);
        }
    }
}