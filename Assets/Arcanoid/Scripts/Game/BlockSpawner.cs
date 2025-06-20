using UnityEngine;

namespace Arcanoid.Scripts.Game
{
    public class BlockSpawner : MonoBehaviour
    {
        public GameObject blockPrefab;
        public int rows = 3;
        public float spacing = 0.1f; // отступ между блоками

        void Start()
        {
            SpawnBlocks();
        }

        void SpawnBlocks()
        {
            Camera cam = Camera.main;

            // Границы экрана в мировых координатах
            Vector2 bottomLeft = cam.ViewportToWorldPoint(new Vector3(0, 0));
            Vector2 topRight = cam.ViewportToWorldPoint(new Vector3(1, 1));

            float screenWidth = topRight.x - bottomLeft.x;

            // Получаем ширину блока
            float blockWidth = blockPrefab.GetComponent<SpriteRenderer>().bounds.size.x;
            float blockHeight = blockPrefab.GetComponent<SpriteRenderer>().bounds.size.y;

            // Кол-во блоков, которое помещается по ширине с учетом spacing
            int blocksPerRow = Mathf.FloorToInt((screenWidth + spacing) / (blockWidth + spacing));

            // Начальная позиция (левый верх)
            Vector3 startPos = new Vector3(
                bottomLeft.x + (screenWidth - (blocksPerRow * (blockWidth + spacing)) + spacing) / 2 + blockWidth / 2,
                topRight.y - 1f, // отступ сверху
                0);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < blocksPerRow; col++)
                {
                    Vector3 pos = startPos + new Vector3(
                        col * (blockWidth + spacing),
                        -row * (blockHeight + spacing),
                        0);

                    var block = Instantiate(blockPrefab, pos, Quaternion.identity, this.transform);
                    block.SetActive(true);
                }
            }
        }
    }
}