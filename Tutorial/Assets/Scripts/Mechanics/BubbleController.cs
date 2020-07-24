using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Gameplay;
using static Platformer.Core.Simulation;

namespace Platformer.Mechanics
{

    [RequireComponent(typeof(Collider2D))]
    public class BubbleController : MonoBehaviour
    {

        void OnTriggerEnter2D(Collider2D other)
        {
            //only exectue OnPlayerEnter if the player collides with this token.
            var player = other.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                Schedule<PlayerHealthDecrease>();
            }
        }
    }
}