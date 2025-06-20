using a;
using strange.extensions.context.impl;

namespace Arcanoid.Scripts.Game
{
    public class GameRoot : ContextView
    {
        void Awake()
        {
            context = new GameContext(this);
        }
    }
}