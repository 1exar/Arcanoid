using strange.extensions.mediation.impl;
using UnityEngine;

namespace Arcanoid.Scripts.Game
{
    public class GameMediator : Mediator
    {
        [Inject] public GameView view { get; set; }
        [Inject] public BallCollisionSignal collisionSignal { get; set; }


        private void Start()
        {
            collisionSignal.AddListener(CheckExistedBlocks);
        }

        private void CheckExistedBlocks(string s)
        {
            if (view.Spawner.ExistBlocksCount() == 0)
            {
                Debug.LogError("win");
            }
        }

        private void OnDestroy()
        {
            collisionSignal.RemoveListener(CheckExistedBlocks);
        }
    }

}