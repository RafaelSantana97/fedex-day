using System.Collections;
using System.Collections.Generic;
using Platformer.Core;
using Platformer.Model;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace Platformer.Gameplay
{
    public class PlayerHealthAddCoin : Simulation.Event<PlayerHealthAddCoin>
    {
        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public override void Execute()
        {
            var player = model.player;
            var playerHealt = player.health;
            playerHealt.AddCoin(1);
        }

    }
}