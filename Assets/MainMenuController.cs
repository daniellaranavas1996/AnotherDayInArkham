using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Coger los valores de los settings.


    }

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


    // Update is called once per frame
    void Update()
    {
        
    }
}

