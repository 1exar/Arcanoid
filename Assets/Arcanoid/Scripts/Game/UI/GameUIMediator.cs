using strange.extensions.mediation.impl;

namespace Arcanoid.Scripts.Game.UI
{
    public class GameUIMediator : Mediator
    {
        [Inject] public GameUIView View { get; set; }
    }
}
