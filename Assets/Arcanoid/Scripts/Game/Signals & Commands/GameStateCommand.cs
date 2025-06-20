using strange.extensions.command.impl;
using UnityEngine;

namespace Arcanoid.Scripts.Game
{
    public class GameStateCommand : Command
    {
        [Inject] public string state { get; set; }

        public override void Execute()
        {
            Debug.Log("Game ended: " + state);
            if (state == "Lose")
            {
               // UnityEngine.SceneManagement.SceneManager.LoadScene("MenuScene");
            }
        }
    }
}