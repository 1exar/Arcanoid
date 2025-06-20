using strange.extensions.mediation.impl;
using UnityEngine;

namespace Arcanoid.Scripts.Menu
{
    public class MenuMediator : Mediator
    {
        [Inject] public MenuView view { get; set; }
        [Inject] public StartGameSignal startGameSignal { get; set; }

        public override void OnRegister()
        {
            view.startButton.onClick.AddListener(OnStartClicked);
        }

        private void OnStartClicked()
        {
            startGameSignal.Dispatch();
        }
    }
}