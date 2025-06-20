using strange.extensions.context.impl;

namespace Arcanoid.Scripts.Menu
{
    public class MenuRoot : ContextView
    {
        void Awake()
        {
            context = new MenuContext(this);
        }
    }
}