using Arcanoid.Scripts.Configs;
using Arcanoid.Scripts.Menu.Singals___Commands;
using Arcanoid.Scripts.Services.Audio;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.impl;
using UnityEngine;

namespace Arcanoid.Scripts.Menu.Context
{
    public class MenuContext : MVCSContext
    {
        public MenuContext(MonoBehaviour view) : base(view) { }

        protected override void addCoreComponents()
        {
            base.addCoreComponents();
            injectionBinder.Unbind<ICommandBinder>();
            injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();
        }
        
        protected override void mapBindings()
        {
            var audioLibrary = Resources.Load<AudioLibrarySO>("AudioLibrary");
            
            injectionBinder.Bind<AudioLibrarySO>().ToValue(audioLibrary);
            injectionBinder.Bind<IAudioService>().To<AudioService>().ToSingleton();
            
            injectionBinder.Bind<StartGameSignal>().ToSingleton();
            
            commandBinder.Bind<PlaySoundSignal>().To<PlaySoundCommand>();
            commandBinder.Bind<StartGameSignal>().To<StartGameCommand>();
            
            mediationBinder.Bind<MenuView>().To<MenuMediator>();
        }
    }
}