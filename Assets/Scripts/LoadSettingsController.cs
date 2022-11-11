using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class LoadSettingsController : MonoBehaviour
{

    [SerializeField] private AudioMixer audioMixer;


    // Start is called before the first frame update
    Resolution[] resolutions;
    private void Start()
    {




        resolutions = Screen.resolutions;


        int ResIndex = PlayerPrefs.GetInt("ResIndex");
        int IsFullScreen = PlayerPrefs.GetInt("FullScreen");
        float volumen = PlayerPrefs.GetFloat("GeneralVolume");

        if (ResIndex > -1)
        {
            Resolution resolution = resolutions[ResIndex];
            Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);


        }



        if (volumen < 20)
        {
            audioMixer.SetFloat("GeneralVolume", volumen);
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
