using strange.extensions.context.impl;

namespace Arcanoid.Scripts.Game.Context
{
    public class GameRoot : ContextView
    {
        private void Awake()
        {
            context = new GameContext(this);
        }
    }
}