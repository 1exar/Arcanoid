using Arcanoid.Scripts.Menu.Singals___Commands;
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
            injectionBinder.Bind<StartGameSignal>().ToSingleton();

            commandBinder.Bind<StartGameSignal>().To<StartGameCommand>();
            mediationBinder.Bind<MenuView>().To<MenuMediator>();
        }
    }
}