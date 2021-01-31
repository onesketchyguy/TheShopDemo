using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Characters.Dialogue
{
    public class DialogueDisplay : MonoBehaviour
    {
        [SerializeField]
        private Text dialogueText;

        [SerializeField]
        private Transform buttonParent;

        [SerializeField]
        private GameObject buttonPrefab;

        [SerializeField]
        private int maxButtons = 4;

        private Button[] buttonObjects;

        [SerializeField]
        private AudioClip voiceSound;

        [SerializeField]
        private AudioSource audioSource;

        public void DisplayDialogue(DialogueChunk chunk)
        {
            // Display the chunk

            // Hide any existing buttons
            ClearButtons();

            // Setup the buttons

            for (int i = 0; i < chunk.buttons.Length; i++)
            {
                // Make sure we only show the max number of buttons
                if (i >= maxButtons) break;

                // Add this event to this button

                int index = i;

                buttonObjects[i].onClick.AddListener(() =>
                {
                    chunk.buttons[index].onClickEvent.Invoke();
                });

                // Try to set the text
                var text = buttonObjects[i].GetComponentInChildren<Text>();
                if (text != null)
                {
                    text.text = chunk.buttons[i].text;
                }

                // Enable this button
                buttonObjects[i].gameObject.SetActive(true);
            }

            // Display the text
            StartCoroutine(ShowText(chunk.text));
        }

        private IEnumerator ShowText(string textToShow)
        {
            dialogueText.text = "";
            yield return null;

            for (int i = 0; i < textToShow.Length; i++)
            {
                dialogueText.text += textToShow[i];
                yield return null;

                // Play a sound effect half of the time
                if (Random.value > 0.5f)
                {
                    if (voiceSound != null)
                    {
                        PlayClip(voiceSound);

                        // Wait out most of the sound before we play another
                        yield return new WaitForSeconds(voiceSound.length * 0.75f);
                    }
                }
            }
        }

        /// <summary>
        /// Hides the buttons from the user.
        /// </summary>
        private void ClearButtons()
        {
            if (buttonObjects == null || buttonObjects.Length == 0)
            {
                buttonObjects = new Button[maxButtons];

                for (int i = 0; i < maxButtons; i++)
                {
                    buttonObjects[i] = Instantiate(buttonPrefab, buttonParent).GetComponent<Button>();
                }
            }

            foreach (var item in buttonObjects)
            {
                item.onClick.RemoveAllListeners();
                item.gameObject.SetActive(false);
            }
        }

        private void PlayClip(AudioClip clip)
        {
            if (audioSource != null)
                audioSource.PlayOneShot(clip);
        }
    }
}