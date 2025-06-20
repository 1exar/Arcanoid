using strange.extensions.mediation.impl;
using UnityEngine;

namespace Arcanoid.Scripts.Game.Ball
{
    public class BallView : View
    {
        [SerializeField] private Rigidbody2D rigidBody;
        [SerializeField] private float speed;

        public Rigidbody2D RigidBody => rigidBody;
        public float Speed => speed;
    }
}