using UnityEngine;

namespace Characters.Input
{
    public class HidePlayerControls : MonoBehaviour
    {
        private PlayerInputManager inputManager;

        private bool VerifyInputManager()
        {
            if (inputManager == null)
            {
                inputManager = FindObjectOfType<PlayerInputManager>();

                return inputManager != null;
            }

            return true;
        }

        private void OnEnable()
        {
            if (VerifyInputManager())
                inputManager.SetPlayerControlEnabled(false);
        }

        private void OnDisable()
        {
            if (VerifyInputManager())
                inputManager.SetPlayerControlEnabled(true);
        }
    }
}