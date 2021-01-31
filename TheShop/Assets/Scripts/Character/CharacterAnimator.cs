using UnityEngine;

namespace Characters
{
    public enum FaceDirection
    {
        unidentified = -1,
        down = 0,
        left = 1,
        up = 2,
        right = 3
    }

    public class CharacterAnimator : MonoBehaviour
    {
        // --------- Inspector items ------------
        [Header("Setup fields")]
        [SerializeField]
        private FaceDirection faceDirection = FaceDirection.down;

        [SerializeField]
        private CharacterMovement movement;

        [SerializeField]
        private Animator anim;

        [Header("Animator fields")]
        [SerializeField]
        private string animFaceDirectionName = "FaceDirection";

        [SerializeField]
        private string animMoveSpeedName = "MoveSpeed";

        // --------- Private items --------------
        private float moveSpeed = 0;

        public float GetMoveSpeed() => moveSpeed;

        private void Update()
        {
            // Set our move speed variable if we can move at all
            if (movement != null)
            {
                float x = movement.HorizontalInput;
                float y = movement.VerticalInput;

                // We use the absolute value to ensure it's above 0
                moveSpeed = Mathf.Abs(x) + Mathf.Abs(y);

                // Set our new look direction based off of movement
                var newLookDirection = FaceDirection.unidentified;

                // Y comes first so we can prioritize left and right look directions
                if (y > 0)
                {
                    newLookDirection = FaceDirection.up;
                }
                else if (y < 0)
                {
                    newLookDirection = FaceDirection.down;
                }

                if (x < 0)
                {
                    newLookDirection = FaceDirection.left;
                }
                else if (x > 0)
                {
                    newLookDirection = FaceDirection.right;
                }

                faceDirection = newLookDirection != FaceDirection.unidentified ?
                    newLookDirection : faceDirection;
            }

            // Set the animation variables
            anim.SetInteger(animFaceDirectionName, (int)faceDirection);
            anim.SetFloat(animMoveSpeedName, moveSpeed);
        }
    }
}