using UnityEngine.Events;

namespace Characters.Dialogue
{
    [System.Serializable]
    public class DialogueChunk
    {
        public string text;

        public ButtonEvent[] buttons;
    }

    [System.Serializable]
    public class ButtonEvent
    {
        public string text;
        public UnityEvent onClickEvent;
    }
}