using System;
using UnityEngine;

namespace Arcanoid.Scripts.Game
{
    public class BallController : MonoBehaviour
    {
        public Rigidbody2D rb;
        public float speed = 6f;

        private void Start()
        {
            rb.velocity = Vector2.up;
        }

        void FixedUpdate()
        {
            rb.velocity = speed * (rb.velocity.normalized);
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            Vector2 dir = rb.velocity.normalized;
            if (Mathf.Abs(dir.x) < 0.1f)
                dir.x = Mathf.Sign(dir.x) * 0.2f;
            if (Mathf.Abs(dir.y) < 0.1f)
                dir.y = Mathf.Sign(dir.y) * 0.2f;

            rb.velocity = dir * speed;
        }
    }
}