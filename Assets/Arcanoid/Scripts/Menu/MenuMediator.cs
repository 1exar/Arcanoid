using Arcanoid.Scripts.Menu.Singals___Commands;
using Arcanoid.Scripts.Services.Audio;
using strange.extensions.mediation.impl;

namespace Arcanoid.Scripts.Menu
{
    public class MenuMediator : Mediator
    {
        [Inject] public MenuView View { get; set; }
        [Inject] public StartGameSignal StartGameSignal { get; set; }
        [Inject] public PlaySoundSignal PlaySoundSignal { get; set; }

        public override void OnRegister()
        {
            View.startButton.onClick.AddListener(OnStartClicked);
        }

        private void OnStartClicked()
        {
            PlaySoundSignal.Dispatch(Sound.ButtonClick);
            StartGameSignal.Dispatch();
        }
        
        public override void OnRemove()
        {
            View.startButton.onClick.RemoveListener(OnStartClicked);
        }

    }
}