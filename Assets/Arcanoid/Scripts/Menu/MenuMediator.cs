using Arcanoid.Scripts.Menu.Singals___Commands;
using strange.extensions.mediation.impl;

namespace Arcanoid.Scripts.Menu
{
    public class MenuMediator : Mediator
    {
        [Inject] public MenuView View { get; set; }
        [Inject] public StartGameSignal StartGameSignal { get; set; }

        public override void OnRegister()
        {
            View.startButton.onClick.AddListener(OnStartClicked);
        }

        private void OnStartClicked()
        {
            StartGameSignal.Dispatch();
        }
        
        public override void OnRemove()
        {
            View.startButton.onClick.RemoveListener(OnStartClicked);
        }

    }
}