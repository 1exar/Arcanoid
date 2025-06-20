using Arcanoid.Scripts.Game;
using strange.extensions.command.impl;

public class BallCollisionCommand : Command
{
    [Inject] public string target { get; set; }

    [Inject] public GameStateSignal gameStateSignal { get; set; }

    public override void Execute()
    {
        if (target == "Bottom")
        {
            gameStateSignal.Dispatch("Lose");
        }
    }
}