using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField] bool respawReady = true;
    [SerializeField] float respawCooldown = 4.5f;
    [SerializeField] Platformer.Mechanics.EnemyCorona[] enemies;

    private void Start() {
    }

    void Update() {
        if (respawReady) {
            respawReady = false;
            StartCoroutine(RespawnEnemy());
        }

    }


    private IEnumerator RespawnEnemy() {

        Vector3 enemyRespawn = new Vector2(transform.position.x + Random.Range(-3.0f, 3.0f), -0.846f);

        if (enemyRespawn.x >= transform.position.x) {
            enemyRespawn.x += 2.9f;
        } else {
            enemyRespawn.x -= 2.9f;
        }

        Platformer.Mechanics.EnemyCorona enemy = Instantiate(enemies[Random.Range(0, enemies.Length)], enemyRespawn, transform.rotation);
        yield return new WaitForSeconds(respawCooldown);
        respawReady = true;
    }
}
