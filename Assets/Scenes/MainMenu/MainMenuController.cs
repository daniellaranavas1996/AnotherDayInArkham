using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Start is called before the first frame update


    public void OpenSettings()
    {
        //
        SceneManager.LoadScene(2);

    }

    public void CloseGame()
    {
        //
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(3);
    }

    // Update is called once per frame

}

