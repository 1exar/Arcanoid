using Arcanoid.Scripts.Game.UI;
using strange.extensions.mediation.impl;
using UnityEngine;

namespace Arcanoid.Scripts.Game
{
    public class GameView : View
    {
        [SerializeField] private GameUIView gameUIView;
        [SerializeField] private BlockSpawner spawner;
        
        public BlockSpawner Spawner => spawner;
        public GameUIView GameUIView => gameUIView;
    }

}