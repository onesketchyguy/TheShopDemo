using UnityEngine;

namespace Characters.Player
{
    public class MoneyManager : MonoBehaviour
    {
        public double currentMoney { get; private set; }

        [SerializeField]
        private double startingMoney = 1000;

        private void Start()
        {
            currentMoney = startingMoney;
        }

        public void DoTransaction(double cost)
        {
            if (currentMoney >= cost)
                currentMoney -= cost;
        }
    }
}