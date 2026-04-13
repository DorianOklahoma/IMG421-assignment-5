using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : MonoBehaviour
{
    [Tooltip("The amount of valuables allowed to be hit before the player loses")]
    public int allowedHits = 1;
    void Start()
    {
        if (GameManager.ballistaDifficulty > 0)
        {
            transform.Find("Ballistas").gameObject.SetActive(true);
        }
        else
        {
            transform.Find("Ballistas").gameObject.SetActive(false);
        }

        if (GameManager.valuablesDifficulty > 0)
        {
            transform.Find("Valuables").gameObject.SetActive(true);
        }
        else
        {
            transform.Find("Valuables").gameObject.SetActive(false);
        }
        Valuable.ResetHits();
    }

    void Update()
    {
        if (GameManager.valuablesDifficulty == 1)
        {
            if (Valuable.GetTotalHits() > allowedHits && !Goal.goalMet)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("_Lose_Scene");
            }
        }
        if (GameManager.valuablesDifficulty == 2)
        {
            if (Valuable.GetTotalHits() > 0 && !Goal.goalMet)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("_Lose_Scene");
            }
        }
    }
}
