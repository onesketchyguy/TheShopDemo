using UnityEngine;
using UnityEngine.UI;

namespace Characters.Player
{
    public class MoneyDisplay : MonoBehaviour
    {
        [SerializeField]
        private Text displayText;

        [SerializeField]
        private MoneyManager moneyManager;

        private void Update()
        {
            if (Time.frameCount % 10 == 0)
                displayText.text = moneyManager.currentMoney.ToString();
        }
    }
}