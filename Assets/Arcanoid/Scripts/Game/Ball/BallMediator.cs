using Arcanoid.Scripts.Game.Signals___Commands;
using strange.extensions.mediation.impl;
using UnityEngine;

namespace Arcanoid.Scripts.Game.Ball
{
    public class BallMediator : Mediator
    {
        
        [Inject] public BallView View { get; set; }
        [Inject] public BallCollisionSignal CollisionSignal { get; set; }
        [Inject] public GameStateSignal GameStateSignal { get; set; }
        
        private Rigidbody2D _rb;
        private float _speed;

        private void Start()
        {
            _rb = View.RigidBody;
            _speed = View.Speed;
            
            _rb.velocity = Vector2.up;
            
            GameStateSignal.AddOnce(OnGameEnd);
        }

        private void OnGameEnd(GameState state)
        {
            if (state == GameState.LOSE || state == GameState.WIN)
            {
                _rb.velocity = Vector2.zero;
            }
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
                Destroy(collision.gameObject);
                CollisionSignal.Dispatch("Block");
            }

            _rb.velocity = dir * _speed;
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Bottom"))
                CollisionSignal.Dispatch("Bottom");
        }
    }
}