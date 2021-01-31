using UnityEngine;

namespace Prototypes
{
    public class PlayerOutfitManager : MonoBehaviour
    {
        [SerializeField]
        private int startingIndex;

        private int currentIndex;

        [SerializeField]
        private Animator animator;

        // This obviously wouldn't be a final product thing, but for the sake of a 48 hour prototype this will have to do
        [SerializeField]
        private AnimatorOverrideController[] outfits;

        // Start is called before the first frame update
        private void Start()
        {
            EquipOutfit(startingIndex);
        }

        public AnimatorOverrideController GetCurrentOutfit()
        {
            return outfits[currentIndex];
        }

        /// <summary>
        /// Swaps the animator controller to a controller from a specified index.
        /// </summary>
        /// <param name="index"></param>
        public void EquipOutfit(int index)
        {
            animator.runtimeAnimatorController = outfits[index];
            currentIndex = index;
        }

        /// <summary>
        /// Swaps the animator controller to a specified controller.
        /// </summary>
        /// <param name="controller"></param>
        public void EquipOutfit(AnimatorOverrideController controller)
        {
            for (int i = 0; i < outfits.Length; i++)
            {
                if (outfits[i] == controller)
                {
                    EquipOutfit(i);
                    return;
                }
            }

            // If we make it to here something went wrong
            Debug.LogWarning($"Outfit {controller.name} does not exist!");
        }
    }
}