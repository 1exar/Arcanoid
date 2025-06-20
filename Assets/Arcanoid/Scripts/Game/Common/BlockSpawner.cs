using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Arcanoid.Scripts.Game
{
    public class BlockSpawner : MonoBehaviour
    {
        public GameObject blockPrefab;
        public int rows = 3;
        public float spacing = 0.1f;

        public float verticalOffset = 0.5f;

        private List<GameObject> _blocks = new List<GameObject>();
        
        void Start()
        {
            SpawnBlocks();
        }

        public async Task<int> ExistBlocksCount()
        {
            await Task.Delay(1000);
            int exist = 0;
            foreach (var block in _blocks)
            {
                if (block != null) exist++;
            }
            return exist;
        }
        
        void SpawnBlocks()
        {
            Camera cam = Camera.main;

            Vector2 bottomLeft = cam.ViewportToWorldPoint(new Vector3(0, 0));
            Vector2 topRight = cam.ViewportToWorldPoint(new Vector3(1, 1));

            float screenWidth = topRight.x - bottomLeft.x;

            float blockWidth = blockPrefab.GetComponent<SpriteRenderer>().bounds.size.x;
            float blockHeight = blockPrefab.GetComponent<SpriteRenderer>().bounds.size.y;

            int blocksPerRow = Mathf.FloorToInt((screenWidth + spacing) / (blockWidth + spacing));

            Vector3 startPos = new Vector3(
                bottomLeft.x + (screenWidth - (blocksPerRow * (blockWidth + spacing)) + spacing) / 2 + blockWidth / 2,
                topRight.y - verticalOffset,
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
                    _blocks.Add(block);
                    block.SetActive(true);
                }
            }
        }
    }
}
