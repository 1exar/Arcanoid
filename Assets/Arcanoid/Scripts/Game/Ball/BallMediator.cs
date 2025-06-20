using System;
using strange.extensions.mediation.impl;
using UnityEngine;

namespace Arcanoid.Scripts.Game
{
    public class BallMediator : Mediator
    {
        
        [Inject] public BallView view { get; set; }
        [Inject] public BallCollisionSignal collisionSignal { get; set; }
        
        private Rigidbody2D _rb;
        private float _speed;

        private void Start()
        {
            _rb = view.RigidBody;
            _speed = view.Speed;
            
            _rb.velocity = Vector2.up;
        }

        private void FixedUpdate()
        {
            _rb.velocity = _speed * (_rb.velocity.normalized);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Vector2 dir = _rb.velocity.normalized;
            if (Mathf.Abs(dir.x) < 0.1f)
                dir.x = Mathf.Sign(dir.x) * 0.2f;
            if (Mathf.Abs(dir.y) < 0.1f)
                dir.y = Mathf.Sign(dir.y) * 0.2f;
            
            if (collision.gameObject.CompareTag("Block"))
            {
                collisionSignal.Dispatch("Block");
                Destroy(collision.gameObject);
            }

            _rb.velocity = dir * _speed;
        }
        
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Bottom"))
                collisionSignal.Dispatch("Bottom");
        }
    }
}