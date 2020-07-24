using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Gameplay;
using static Platformer.Core.Simulation;

namespace Platformer.Mechanics
{

    [RequireComponent(typeof(Collider2D))]
    public class EnemyCorona : MonoBehaviour 
    {

        [SerializeField] private float timeBeforeDisapear = 3f;

        void Start()
        {
            StartCoroutine(WaitAndDisapear());
        }

        private IEnumerator WaitAndDisapear()
        {
            yield return new WaitForSeconds(timeBeforeDisapear);
            Destroy(gameObject);
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            var player = collision.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                Schedule<PlayerDeath>();
            }
        }
    }
}