namespace Arcanoid.Scripts.Game.Signals___Commands
{
    public class GameStateModel
    {
        public GameState CurrentState { get; private set; } = GameState.Playing;

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