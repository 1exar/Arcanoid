using strange.extensions.context.impl;
using UnityEngine;

namespace Arcanoid.Scripts.Game
{
    public class GameContext : MVCSContext
    {
        public GameContext(MonoBehaviour view) : base(view) { }

        protected override void mapBindings()
        {
            injectionBinder.Bind<GameStateSignal>().ToSingleton();
            injectionBinder.Bind<BallCollisionSignal>().ToSingleton();

            commandBinder.Bind<GameStateSignal>().To<GameStateCommand>();
            commandBinder.Bind<BallCollisionSignal>().To<BallCollisionCommand>();

            mediationBinder.Bind<GameView>().To<GameMediator>();
            mediationBinder.Bind<BallView>().To<BallMediator>();
        }
    }
}