using UnityEngine;

namespace Prototypes
{
    /// <summary>
    /// A temporary script used solely for exiting the application once a function is called.
    /// </summary>
    public class ExitApp : MonoBehaviour
    {
        public void Exit()
        {
            Application.Quit();
        }
    }
}