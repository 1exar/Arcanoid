using Arcanoid.Scripts.Game.Signals___Commands;
using Arcanoid.Scripts.Services.Audio;
using DG.Tweening;
using strange.extensions.mediation.impl;
using UnityEngine;

namespace Arcanoid.Scripts.Game.Ball
{
    public class BallMediator : Mediator
    {
        
        [Inject] public BallView View { get; set; }
        [Inject] public BallCollisionSignal CollisionSignal { get; set; }
        [Inject] public GameStateSignal GameStateSignal { get; set; }
        [Inject] public PlaySoundSignal PlaySoundSignal { get; set; }
        
        private Rigidbody2D _rb;
        private float _speed;

        private bool _gameStart;

        private void Start()
        {
            _rb = View.RigidBody;
            _speed = View.Speed;
            
            GameStateSignal.AddOnce(OnGameEnd);
        }

        private void OnGameEnd(GameState state)
        {
            if (state == GameState.Lose || state == GameState.Win)
            {
                if(_rb != null)
                    _rb.velocity = Vector2.zero;
            }
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && _gameStart == false)
            {
                _gameStart = true;
                _rb.velocity = Vector2.up;
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

            switch (collision.gameObject.tag)
            {
                case "Block":
                    var block = collision.gameObject;
                    
                    PlaySoundSignal.Dispatch(Sound.Hit);

                    block.transform.DOScale(Vector3.zero, .1f).OnComplete((() =>
                    {
                        Destroy(block);
                        CollisionSignal.Dispatch("Block");
                    }));
                    break;
                
                case "Bottom":
                    PlaySoundSignal.Dispatch(Sound.Bounce);
                    collision.gameObject.transform.DOShakeScale(.1f, .2f, 2);
                    break;
                
                default:
                    PlaySoundSignal.Dispatch(Sound.Bounce);
                    break;
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