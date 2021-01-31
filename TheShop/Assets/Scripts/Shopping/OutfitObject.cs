using UnityEngine;

namespace Characters
{
    [CreateAssetMenu(fileName = "New outfit", menuName = "Shop Outfit")]
    public class OutfitObject : ScriptableObject
    {
        public AnimatorOverrideController Animator;

        public Sprite icon;

        public string description;

        public double cost;
    }
}