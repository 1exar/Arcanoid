using UnityEngine;
using UnityEngine.Events;

namespace Arcanoid.Scripts.Game
{
    public class BallCollision : MonoBehaviour
    {
        public UnityEvent<string> OnCollisionEvent = new UnityEvent<string>();

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Bottom"))
                OnCollisionEvent.Invoke("Bottom");

            if (other.CompareTag("Block"))
            {
                OnCollisionEvent.Invoke("Block");
                Destroy(other.gameObject);
            }
        }
    }
}