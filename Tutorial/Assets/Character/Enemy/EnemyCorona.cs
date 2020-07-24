using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCorona : MonoBehaviour
{

    [SerializeField] private float timeBeforeDisapear = 3f;

    void Update()
    {
        StartCoroutine(WaitAndDisapear());
    }

    private IEnumerator WaitAndDisapear() {
        yield return new WaitForSeconds(timeBeforeDisapear);
        Destroy(gameObject);
    }
}
