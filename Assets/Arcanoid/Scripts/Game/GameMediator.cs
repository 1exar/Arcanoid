using Arcanoid.Scripts.Game.Ball;
using Arcanoid.Scripts.Game.Signals___Commands;
using Arcanoid.Scripts.Game.UI;
using Arcanoid.Scripts.Services.Audio;
using strange.extensions.mediation.impl;

namespace Arcanoid.Scripts.Game
{
    public class GameMediator : Mediator
    {
        [Inject] public GameView View { get; set; }
        [Inject] public BallCollisionSignal CollisionSignal { get; set; }
        [Inject] public GameStateSignal GameStateSignal { get; set; }
        [Inject] public GameStateModel GameStateModel { get; set; }
        [Inject] public PlaySoundSignal PlaySoundSignal { get; set; }

        private GameUIView UIView => View.GameUIView;
        
        private int _score;
        
        private void Start()
        {
            CollisionSignal.AddListener(OnBallCollider);
        }

        private async void OnBallCollider(string collisionTag)
        {
            if(GameStateModel.CurrentState != GameState.Playing) return;
            switch (collisionTag)
            {
                case "Block":
                    _score++;
                    
                    UIView.SetScore(_score);
                    
                    if (await View.Spawner.ExistBlocksCount() == 0)
                    {
                        PlaySoundSignal.Dispatch(Sound.Win);
                        GameStateSignal.Dispatch(GameState.Win);
                        UIView.ShowGameOverPanel(true, _score);
                    }
                    break;
                
                case "Bottom":
                    PlaySoundSignal.Dispatch(Sound.Lose);
                    GameStateSignal.Dispatch(GameState.Lose);
                    UIView.ShowGameOverPanel(false, _score);
                    break;
            }
        }

        private void OnDestroy()
        {
            CollisionSignal.RemoveListener(OnBallCollider);
        }
    }

}