using Arcanoid.Scripts.Game.Common;
using strange.extensions.mediation.impl;
using UnityEngine;

namespace Arcanoid.Scripts.Game
{
    public class GameView : View
    {

        [SerializeField] private BlockSpawner spawner;
        
        public BlockSpawner Spawner => spawner;

    }

}