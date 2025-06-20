using strange.extensions.context.impl;

namespace Arcanoid.Scripts.Menu.Context
{
    public class MenuRoot : ContextView
    {
        private void Awake()
        {
            context = new MenuContext(this);
        }
    }
}