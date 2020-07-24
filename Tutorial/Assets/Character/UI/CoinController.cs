using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{

    public void UpdateCoins(int coins)
    {
        gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "Score: " + coins.ToString();
    }
}
