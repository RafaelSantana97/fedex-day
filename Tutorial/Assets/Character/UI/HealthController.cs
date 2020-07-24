using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField] GameObject[] hearts;


    public void DisplayHeart(int health, bool increase) {

        if (increase) {
            if (health != 3) {
                hearts[health].SetActive(true);
                hearts[health - 1].SetActive(false);
            }
        } else {
            hearts[health + 1].SetActive(false);
            hearts[health].SetActive(true);
        }
    }
}
