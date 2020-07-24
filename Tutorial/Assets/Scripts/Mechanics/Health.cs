using System;
using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;
using UnityEngine.SceneManagement;

namespace Platformer.Mechanics
{
    /// <summary>
    /// Represebts the current vital statistics of some game entity.
    /// </summary>
    public class Health : MonoBehaviour
    {

        public int Coins { get; set; }

        /// <summary>
        /// The maximum hit points for the entity.
        /// </summary>
        public int maxHP = 3;

        /// <summary>
        /// Indicates if the entity should be considered 'alive'.
        /// </summary>
        public bool IsAlive => currentHP > 0;

        public int currentHP { private set; get; }


        public void AddCoin(int coinsToAdd) => this.Coins += coinsToAdd;

        public void LostAllCoins() => this.Coins = 0;

        public void LostCoins(int coinsToLost) => this.Coins = (this.Coins - coinsToLost) >= 0 ? (this.Coins - coinsToLost) : 0;



        /// <summary>
        /// Increment the HP of the entity.
        /// </summary>
        public void Increment()
        {
            if (currentHP < this.maxHP)
            {
                currentHP = Mathf.Clamp(currentHP + 1, 0, maxHP);
                FindObjectOfType<HealthController>().DisplayHeart(currentHP, true);
            }
        }

        /// <summary>
        /// Decrement the HP of the entity. Will trigger a HealthIsZero event when
        /// current HP reaches 0.
        /// </summary>
        public void Decrement()
        {
            currentHP = Mathf.Clamp(currentHP - 1, 0, maxHP);
            FindObjectOfType<HealthController>().DisplayHeart(currentHP, false);
            if (currentHP == 0)
            {
                var ev = Schedule<HealthIsZero>();
                ev.health = this;
            }
        }

        /// <summary>
        /// Decrement the HP of the entitiy until HP reaches 0.
        /// </summary>
        public void Die()
        {
            while (currentHP > 0) Decrement();
            SceneManager.LoadScene(0);
        }

        void Awake()
        {
            currentHP = maxHP;
            this.LostAllCoins();
        }
    }
}
