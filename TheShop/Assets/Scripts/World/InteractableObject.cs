using UnityEngine;
using UnityEngine.Events;

namespace World.Interaction
{
    [RequireComponent(typeof(Collider2D))]
    public class InteractableObject : MonoBehaviour, IInteractable
    {
        public UnityEvent onInteractEvent;

        /// <summary>
        /// Trigger this interaction to happen.
        /// </summary>
        public void OnInteracted()
        {
            onInteractEvent?.Invoke();
        }
    }
}