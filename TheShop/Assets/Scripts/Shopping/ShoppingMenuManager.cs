using UnityEngine;
using UnityEngine.UI;
using Characters;
using System.Collections.Generic;
using Characters.Player;

namespace Prototypes
{
    public class ShoppingMenuManager : MonoBehaviour
    {
        [SerializeField]
        private Text costText;

        [SerializeField]
        private Text descriptionText;

        [SerializeField]
        private Image displayImage;

        [SerializeField]
        private Image currentOutfitDisplay;

        [SerializeField]
        private Text buttonText;

        [SerializeField]
        private GameObject buyOutfitDisplay;

        [SerializeField]
        private OutfitObject[] outfits;

        [SerializeField]
        private List<OutfitObject> ownedOutfits = new List<OutfitObject>();

        [SerializeField]
        private PlayerOutfitManager outfitManager;

        [SerializeField]
        private MoneyManager moneyManager;

        /// <summary>
        /// The index of the outfit currently on screen.
        /// </summary>
        private int displayIndex;

        private int currentEquippedIndex;

        private void Start()
        {
            var outfit = outfitManager.GetCurrentOutfit();

            for (int i = 0; i < outfits.Length; i++)
            {
                if (outfit == outfits[i].Animator)
                {
                    ownedOutfits.Add(outfits[i]);
                    currentEquippedIndex = i;
                }
            }

            Display();
        }

        public void Cycle(int dir)
        {
            if (displayIndex + dir >= outfits.Length)
                displayIndex = 0;
            else if (displayIndex + dir < 0)
                displayIndex = outfits.Length - 1;
            else displayIndex += dir;

            Display();
        }

        private void Display()
        {
            // Grab the outfit from the "wardrobe"
            var outfit = outfits[displayIndex];

            // Update the display options
            descriptionText.text = outfit.description;
            displayImage.sprite = outfit.icon;

            // Update the purchase/equip options
            if (ownedOutfits.Contains(outfit))
            {
                buyOutfitDisplay.SetActive(false);
                descriptionText.text += "\nYou own this!";
                buttonText.text = "Equip";
            }
            else
            {
                buyOutfitDisplay.SetActive(true);
                costText.text = outfit.cost.ToString();
                buttonText.text = "Purchase";
            }

            // Update current outfit
            currentOutfitDisplay.sprite = outfits[currentEquippedIndex].icon;
        }

        public void Purchase()
        {
            // Buy or equip the outfit

            if (ownedOutfits.Contains(outfits[displayIndex]))
            {
                // Equip outfit
                outfitManager.EquipOutfit(outfits[displayIndex].Animator);
                currentEquippedIndex = displayIndex;
            }
            else
            {
                // Purchase outfit
                ownedOutfits.Add(outfits[displayIndex]);

                moneyManager.DoTransaction(outfits[displayIndex].cost);
            }

            Display();
        }
    }
}