using UnityEngine;

namespace World
{
    public class LayerSorter : MonoBehaviour
    {
        private struct SortableSprite
        {
            private SpriteRenderer spriteRenderer;
            private int startingIndex;

            public SortableSprite(SpriteRenderer renderer)
            {
                spriteRenderer = renderer;
                startingIndex = renderer.sortingOrder * 100;
            }

            public void Update()
            {
                float yPos = spriteRenderer.transform.position.y;
                int off = Mathf.RoundToInt(yPos * -1000);

                spriteRenderer.sortingOrder = startingIndex + off;
            }
        }

        private SortableSprite[] sortableSprites;

        private void Start()
        {
            InitializeRenderers();
        }

        private void LateUpdate()
        {
            for (int i = 0; i < sortableSprites.Length; i++)
            {
                sortableSprites[i].Update();
            }
        }

        private void InitializeRenderers()
        {
            var renderers = GetComponentsInChildren<SpriteRenderer>();
            sortableSprites = new SortableSprite[renderers.Length];

            for (int i = 0; i < renderers.Length; i++)
            {
                sortableSprites[i] = new SortableSprite(renderers[i]);
            }
        }
    }
}