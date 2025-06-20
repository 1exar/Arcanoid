using UnityEngine;

namespace Arcanoid.Scripts.Game
{
    public class ScreenBoundsWalls : MonoBehaviour
    {
        public float wallThickness = 1f;

        void Start()
        {
            CreateWalls();
        }

        void CreateWalls()
        {
            Camera cam = Camera.main;
            float z = 0f;

            Vector2 bottomLeft = cam.ScreenToWorldPoint(new Vector3(0, 0, z));
            Vector2 topRight = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, z));

            float screenWidth = topRight.x - bottomLeft.x;
            float screenHeight = topRight.y - bottomLeft.y;

            // Ліва стіна
            CreateWall(new Vector2(bottomLeft.x - wallThickness / 2, 0), new Vector2(wallThickness, screenHeight + 2));

            // Права стіна
            CreateWall(new Vector2(topRight.x + wallThickness / 2, 0), new Vector2(wallThickness, screenHeight + 2));

            // Верхня стіна
            CreateWall(new Vector2(0, topRight.y + wallThickness / 2), new Vector2(screenWidth + 2, wallThickness));

            // Нижня зона поразки
            GameObject bottom = CreateWall(new Vector2(0, bottomLeft.y - wallThickness / 2), new Vector2(screenWidth + 2, wallThickness));
            bottom.tag = "Bottom";
            BoxCollider2D bc = bottom.GetComponent<BoxCollider2D>();
            bc.isTrigger = true;
        }

        GameObject CreateWall(Vector2 position, Vector2 size)
        {
            GameObject wall = new GameObject("Wall");
            wall.transform.position = position;

            BoxCollider2D col = wall.AddComponent<BoxCollider2D>();
            col.size = size;

            wall.transform.parent = this.transform;
            return wall;
        }
    }
}