using System.Collections;
using System.Collections.Generic;
using Platformer.Core;
using Platformer.Model;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace Platformer.Gameplay
{
    /// <summary>
    /// Fired when the player has died.
    /// </summary>
    /// <typeparam name="PlayerDeath"></typeparam>
    public class PlayerHealthDecrease : Simulation.Event<PlayerHealthDecrease>
    {
        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public override void Execute()
        {
            var player = model.player;
            var playerHealt = player.health;
            player.animator.SetTrigger("hurt");
            playerHealt.Decrement();            
            if (!playerHealt.IsAlive)
            {
                Schedule<PlayerDeath>();
            }

        }
    }
}