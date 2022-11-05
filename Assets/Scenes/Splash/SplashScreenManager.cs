using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreenManager : MonoBehaviour
{
    private int sceneNum;
    public static int sceneNumShare;

    // Start is called before the first frame update
    void Start()
    {
        sceneNum = sceneNumShare;

        if (sceneNum == 0)
        {
            StartCoroutine(ToMainMenu());
        }
    }

    IEnumerator ToMainMenu()
    {
        yield return new WaitForSeconds(5);

        SceneManager.LoadScene(1);

    }

    // Update is called once per frame
    void Update()
    {

    }
}



