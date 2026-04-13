using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public void goToMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("_Menu_Scene");
    }
}
