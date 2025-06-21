using Arcanoid.Scripts.Services.Audio;
using strange.extensions.mediation.impl;

namespace Arcanoid.Scripts.Game.UI
{
    public class GameUIMediator : Mediator
    {
        [Inject] public GameUIView View { get; set; }
        [Inject] public PlaySoundSignal PlaySoundSignal { get; set; }

        public override void OnRegister()
        {
            View.restartButton.onClick.AddListener(() =>
            {
                PlaySoundSignal.Dispatch(Sound.ButtonClick);
                UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
            });
            
            View.menuButton.onClick.AddListener(() =>
            {
                PlaySoundSignal.Dispatch(Sound.ButtonClick);
                UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
            });
        }
    }
}
