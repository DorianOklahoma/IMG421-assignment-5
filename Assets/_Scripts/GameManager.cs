using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{   
    static public int windDifficulty = 0;
    static public int ballistaDifficulty = 0;
    static public int valuablesDifficulty = 0;
    public void handleWind(int value)
    {
        windDifficulty = value;
        Debug.Log("Wind set to: " + windDifficulty);
    }

    public void handleBallistas(int value)
    {
        ballistaDifficulty = value;
        Debug.Log("Ballistas set to: " + ballistaDifficulty);
    }

    public void handleValuables(int value)
    {
        valuablesDifficulty = value;
        Debug.Log("Valuables set to: " + valuablesDifficulty);
    }

    public void startGame()
    {
        SceneManager.LoadScene("_scene_0");
    }
}
