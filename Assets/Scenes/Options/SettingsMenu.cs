using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro; 
public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public TMP_Dropdown resolutionDropdown;

    [SerializeField] private Slider volumeSlider = null;
    [SerializeField] private TMPro.TMP_Dropdown dropdown = null;
    [SerializeField] private Toggle toggleFullScreen = null;

    [SerializeField] private Canvas canvasToHide;

    Resolution[] resolutions;
    private void Start()
    {




       resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> listResolutions = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {

            string resol = resolutions[i].width + " x " + resolutions[i].height;
            if (listResolutions.Exists(x => x.Equals(resol)) == false)
            {
                listResolutions.Add(resol);
            }

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height )
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(listResolutions);

        resolutionDropdown.value = currentResolutionIndex;
      
                //LOAD SAVED DATA
        LoadData();
        resolutionDropdown.RefreshShownValue();
    }

    private void LoadData()
    {

        int ResIndex = PlayerPrefs.GetInt("ResIndex");
        int IsFullScreen = PlayerPrefs.GetInt("FullScreen");
        float volumen = PlayerPrefs.GetFloat("GeneralVolume");

        if (ResIndex > -1)
        {
            dropdown.value = ResIndex;
        }

        if (IsFullScreen > -1)
        {
            toggleFullScreen.isOn = IsFullScreen.Equals(1);
        }

        if (volumen < 20)
        {
            volumeSlider.value = volumen;
        }
    }

    public void SetResolution(int resolutionIndex){
        Resolution resolution = resolutions[resolutionIndex];
        PlayerPrefs.SetInt("ResIndex", resolutionIndex);

        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }


    public void SetVolume (float volume)
    {
       
        audioMixer.SetFloat("GeneralVolume", volume);
        PlayerPrefs.SetFloat("GeneralVolume", volume);
    }

    public void SetFullScreen (bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
        PlayerPrefs.SetInt("FullScreen", isFullScreen ? 1:0) ;
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void BackButton()
    {
        canvasToHide.gameObject.SetActive(false);
    }
}
