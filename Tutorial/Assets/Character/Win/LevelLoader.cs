using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    public void GoWinScreen() 
    {
        SceneManager.LoadScene(2);
    }

    public void GoDefeatScreen() {
        SceneManager.LoadScene(3);
    }
}
