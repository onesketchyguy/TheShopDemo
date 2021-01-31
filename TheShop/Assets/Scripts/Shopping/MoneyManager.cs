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

        /// <summary>
        /// Returns wether or not there is enough money for a transaction.
        /// </summary>
        /// <param name="cost"></param>
        /// <returns></returns>
        public bool DoTransaction(double cost)
        {
            if (currentMoney >= cost)
            {
                currentMoney -= cost;
                return true;
            }

            return false;
        }
    }
}