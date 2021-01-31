using UnityEngine;

namespace Characters.Dialogue
{
    public class DialogueCharacter : MonoBehaviour
    {
        public DialogueChunk[] dialogueChunks;

        [SerializeField]
        private DialogueDisplay dialogueDisplay;

        private int currentChunk = 0;

        public void DisplayChunk(int chunk)
        {
            if (dialogueDisplay.gameObject.activeSelf == false)
                dialogueDisplay.gameObject.SetActive(true);

            dialogueDisplay.DisplayDialogue(dialogueChunks[chunk]);
            currentChunk = chunk;
        }

        public void DisplayNextChunk()
        {
            currentChunk++;
            if (currentChunk < dialogueChunks.Length)
            {
                DisplayChunk(currentChunk);
            }
        }

        public void CloseInteraction()
        {
            if (dialogueDisplay.gameObject.activeSelf == true)
                dialogueDisplay.gameObject.SetActive(false);

            currentChunk = 0;
        }
    }
}