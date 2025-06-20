using UnityEngine;

namespace Arcanoid.Scripts.Game
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PaddleController : MonoBehaviour
    {
        [SerializeField] private float speed = 10f;

        private Rigidbody2D _rb;

        private float _halfWidth;
        private float _leftLimit;
        private float _rightLimit;

        private Camera _cam;
        private bool _usingPointer;
        private float _targetX;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _halfWidth = GetComponent<SpriteRenderer>().bounds.size.x / 2f;

            _cam = Camera.main;
            Vector3 leftWorld = _cam.ViewportToWorldPoint(Vector3.zero);
            Vector3 rightWorld = _cam.ViewportToWorldPoint(Vector3.right);

            _leftLimit = leftWorld.x + _halfWidth;
            _rightLimit = rightWorld.x - _halfWidth;
        }

        private void Update()
        {
            _usingPointer = false;

            if (Input.GetMouseButton(0))
            {
                Vector3 worldPos = _cam.ScreenToWorldPoint(Input.mousePosition);
                _targetX = Mathf.Clamp(worldPos.x, _leftLimit, _rightLimit);
                _usingPointer = true;
            }

            else if (Input.touchCount > 0)
            {
                Vector3 worldPos = _cam.ScreenToWorldPoint(Input.GetTouch(0).position);
                _targetX = Mathf.Clamp(worldPos.x, _leftLimit, _rightLimit);
                _usingPointer = true;
            }
        }

        private void FixedUpdate()
        {
            Vector2 pos = _rb.position;

            if (_usingPointer)
            {
                pos.x = _targetX;
            }
            else
            {
                float input = Input.GetAxisRaw("Horizontal");
                pos.x += input * speed * Time.fixedDeltaTime;
                pos.x = Mathf.Clamp(pos.x, _leftLimit, _rightLimit);
            }

            _rb.MovePosition(pos);
        }
    }
}
