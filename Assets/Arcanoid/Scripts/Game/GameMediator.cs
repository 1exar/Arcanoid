using strange.extensions.mediation.impl;

namespace Arcanoid.Scripts.Game
{
    public class GameMediator : Mediator
    {
        [Inject] public GameView view { get; set; }
        [Inject] public BallCollisionSignal collisionSignal { get; set; }

        public override void OnRegister()
        {
            view.ballCollision.OnCollisionEvent.AddListener(OnBallCollision);
        }

        void OnBallCollision(string tag)
        {
            collisionSignal.Dispatch(tag);
        }
    }

}