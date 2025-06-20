using Arcanoid.Scripts.Game.Ball;
using Arcanoid.Scripts.Game.Signals___Commands;
using Arcanoid.Scripts.Game.UI;
using strange.extensions.context.impl;
using UnityEngine;

namespace Arcanoid.Scripts.Game.Context
{
    public class GameContext : MVCSContext
    {
        public GameContext(MonoBehaviour view) : base(view) { }
        
        protected override void mapBindings()
        {
            injectionBinder.Bind<GameStateModel>().ToSingleton();
            injectionBinder.Bind<GameStateSignal>().ToSingleton();
            injectionBinder.Bind<BallCollisionSignal>().ToSingleton();

            commandBinder.Bind<GameStateSignal>().To<GameStateCommand>();

            mediationBinder.Bind<GameUIView>().To<GameUIMediator>();
            mediationBinder.Bind<GameView>().To<GameMediator>();
            mediationBinder.Bind<BallView>().To<BallMediator>();
        }
    }
}