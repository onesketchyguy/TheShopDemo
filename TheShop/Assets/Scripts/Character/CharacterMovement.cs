using UnityEngine;
using Characters.Input;

namespace Characters
{
    /// <summary>
    /// Uses a RigidBody2D to move an object through external input.
    /// </summary>
    [RequireComponent(typeof(Rigidbody2D))]
    public class CharacterMovement : MonoBehaviour, IMoveInputReciever
    {
        // ----------- Inspector fields ----------------

        [SerializeField]
        private Rigidbody2D rigidBody;

        [SerializeField]
        private float moveSpeed = 5;

        // ----------- Script only fields -------------
        public float HorizontalInput { get; set; }

        public float VerticalInput { get; set; }

        // Cache the input to prevent from over initialization
        private Vector2 input = new Vector2();

        /// <summary>
        /// Called every time the component is revalidated in the inspector.
        /// </summary>
        private void OnValidate()
        {
            if (rigidBody == null) rigidBody = GetComponent<Rigidbody2D>();

            if (moveSpeed < 0) moveSpeed = 0.001f;
        }

        /// <summary>
        /// Called every frame.
        /// </summary>
        private void Update()
        {
            input.x = HorizontalInput;
            input.y = VerticalInput;
        }

        /// <summary>
        /// Called on every physics update.
        /// </summary>
        private void FixedUpdate()
        {
            rigidBody.velocity = input * moveSpeed;
        }
    }
}