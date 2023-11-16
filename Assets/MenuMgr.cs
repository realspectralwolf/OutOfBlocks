using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMgr : MonoBehaviour
{
    public void OpenGameplay()
    {
        PlayerPrefs.SetInt("rightplayer", 0);
        PlayerPrefs.SetInt("leftplayer", 0);
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
