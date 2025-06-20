using strange.extensions.command.impl;
using UnityEngine;

namespace Arcanoid.Scripts.Game.Signals___Commands
{
    public class GameStateCommand : Command
    {
        [Inject] public GameState State { get; set; }
        [Inject] public GameStateModel GameStateModel { get; set; }

        public override void Execute()
        {
            GameStateModel.SetState(State);
            Debug.Log($"Game State Changed → {State}");
        }
    }
}