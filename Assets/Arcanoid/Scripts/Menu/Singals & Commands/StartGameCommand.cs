using strange.extensions.command.impl;

namespace Arcanoid.Scripts.Menu.Singals___Commands
{
    public class StartGameCommand : Command
    {
        public override void Execute()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
        }
    }
}