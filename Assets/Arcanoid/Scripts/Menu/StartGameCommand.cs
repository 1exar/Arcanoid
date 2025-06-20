using strange.extensions.command.impl;
using UnityEngine;

namespace Arcanoid.Scripts.Menu
{
    public class StartGameCommand : Command
    {
        public override void Execute()
        {
            Debug.Log("loas game");
            UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
        }
    }
}