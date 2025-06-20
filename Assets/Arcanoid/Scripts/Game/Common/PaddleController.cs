using UnityEngine;

namespace Arcanoid.Scripts.Game
{
    public class PaddleController : MonoBehaviour
    {

        [SerializeField] private float speed;
        
        private void Update()
        {
            float h = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * h * speed * Time.deltaTime);
        }
    }
}