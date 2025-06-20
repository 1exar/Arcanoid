namespace Arcanoid.Scripts.Game.Signals___Commands
{
    public class GameStateModel
    {
        public GameState CurrentState { get; private set; } = GameState.PLAYING;

        public void SetState(GameState state)
        {
            CurrentState = state;
        }

        public bool Is(GameState state)
        {
            return CurrentState == state;
        }
    }
}