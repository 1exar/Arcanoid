using Arcanoid.Scripts.Configs;
using Arcanoid.Scripts.Game.Ball;
using Arcanoid.Scripts.Game.Signals___Commands;
using Arcanoid.Scripts.Game.UI;
using Arcanoid.Scripts.Services.Audio;
using strange.extensions.context.impl;
using UnityEngine;

namespace Arcanoid.Scripts.Game.Context
{
    public class GameContext : MVCSContext
    {
        public GameContext(MonoBehaviour view) : base(view) { }
        
        protected override void mapBindings()
        {
            var audioLibrary = Resources.Load<AudioLibrarySO>("AudioLibrary");
            injectionBinder.Bind<AudioLibrarySO>().ToValue(audioLibrary);

            injectionBinder.Bind<IAudioService>().To<AudioService>().ToSingleton();
            
            injectionBinder.Bind<GameStateModel>().ToSingleton();
            injectionBinder.Bind<GameStateSignal>().ToSingleton();
            injectionBinder.Bind<BallCollisionSignal>().ToSingleton();
            
            commandBinder.Bind<PlaySoundSignal>().To<PlaySoundCommand>();
            commandBinder.Bind<GameStateSignal>().To<GameStateCommand>();

            mediationBinder.Bind<GameUIView>().To<GameUIMediator>();
            mediationBinder.Bind<GameView>().To<GameMediator>();
            mediationBinder.Bind<BallView>().To<BallMediator>();
        }
    }
}