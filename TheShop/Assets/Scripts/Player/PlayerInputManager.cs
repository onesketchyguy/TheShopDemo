using UnityEngine;

namespace Characters.Input
{
    public class PlayerInputManager : MonoBehaviour
    {
        // An array of objects than can recieve input from this
        private IMoveInputReciever[] moveInputRecievers;

        private IActionInputReciever[] actionInputRecievers;

        private InputControls inputControls;

        [SerializeField]
        private UnityEngine.Events.UnityEvent onQuitPressed;

        /// <summary>
        /// Start is called before the first frame update
        /// </summary>
        private void Start()
        {
            // Retrieve all the input recievers on start
            // NOTE: This could become rather performance intensive if not kept under check
            moveInputRecievers = GetComponents<IMoveInputReciever>();
            actionInputRecievers = GetComponents<IActionInputReciever>();

            // Generate the input system
            inputControls = new InputControls();
            inputControls.Enable();

            // We add both to performed and canceled to ensure we recieve the released input.
            inputControls.WorldActions.Movement.performed += HandleMovement;
            inputControls.WorldActions.Movement.canceled += HandleMovement;

            // Setup the accept button control
            inputControls.WorldActions.Accept.performed += Accept_performed;

            // Setup quit button control
            inputControls.WorldActions.Quit.performed += _ => onQuitPressed.Invoke();

            // Enable the input system
            SetPlayerControlEnabled(true);
        }

        private void Accept_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            foreach (var item in actionInputRecievers)
            {
                item.OnAcceptKey();
            }
        }

        private void HandleMovement(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            var move = obj.ReadValue<Vector2>();

            foreach (var item in moveInputRecievers)
            {
                item.HorizontalInput = move.x;
                item.VerticalInput = move.y;
            }
        }

        public void SetPlayerControlEnabled(bool enabled)
        {
            if (enabled)
            {
                inputControls.WorldActions.Enable();
            }
            else
            {
                inputControls.WorldActions.Disable();
            }
        }
    }
}