using UnityEngine;
using Characters.Input;

namespace World.Interaction
{
    public class InteractionManager : MonoBehaviour, IActionInputReciever
    {
        [SerializeField]
        private Vector2 interactionAreaSize = Vector2.one;

        private Transform _transform;

        private Collider2D[] collisions;

        [SerializeField]
        private GameObject onEnterInteractionRangePrompt;

        private void Start()
        {
            // Cache the transform
            _transform = transform;
        }

        private void LateUpdate()
        {
            if (Time.frameCount % 10 == 0)
            {
                onEnterInteractionRangePrompt.SetActive(CheckForInterationPrompt());
            }
        }

        private bool CheckForInterationPrompt()
        {
            // Setup the collision area
            collisions = Physics2D.OverlapBoxAll(_transform.position, interactionAreaSize,
                _transform.rotation.z);

            // Go through every item collided with
            foreach (var collider in collisions)
            {
                if (collider.gameObject == gameObject) continue;

                // Check for the interactable interface
                var interactable = collider.GetComponent<IInteractable>();

                // If that interface exists, display an interaction prompt
                if (interactable != null)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Checks for interatable objects in a local radius, then activates them.
        /// </summary>
        public void OnAcceptKey()
        {
            // Setup the collision area
            collisions = Physics2D.OverlapBoxAll(_transform.position, interactionAreaSize,
                _transform.rotation.z);

            // Go through every item collided with
            foreach (var collider in collisions)
            {
                if (collider.gameObject == gameObject) continue;

                // Check for the interactable interface
                var interactable = collider.GetComponent<IInteractable>();

                // If that interface exists, send an interacted event.
                if (interactable != null) interactable.OnInteracted();
            }
        }

        /// <summary>
        /// Debug the radius that can be interacted with
        /// </summary>
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireCube(transform.position, interactionAreaSize);
        }
    }
}