using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Gameplay;
using static Platformer.Core.Simulation;

namespace Platformer.Mechanics
{

    public class EnemyCoronaDespawn : MonoBehaviour 
    {

        [SerializeField] private float timeBeforeDisapearMin = 2.5f;
        [SerializeField] private float timeBeforeDisapearMax = 4f;

        void Start()
        {
            StartCoroutine(WaitAndDisapear());
        }

        private IEnumerator WaitAndDisapear()
        {
            yield return new WaitForSeconds(Random.Range(timeBeforeDisapearMin, timeBeforeDisapearMax));
            Destroy(gameObject);
        }
    }
}