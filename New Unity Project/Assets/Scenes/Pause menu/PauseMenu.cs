using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Linq;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused;
    public GameObject pauseMenuUI;
    public AudioMixer masterMixer;
    public Slider volumeSlider;
    public Dropdown resDropdown;
    public Toggle fullscreenToggle;
    Resolution[] resolutions;
    void Start()
    {
        float value;
        masterMixer.GetFloat("Volume", out value);
        volumeSlider.value =Mathf.Pow(10f,value/20f);

        resolutions = Screen.resolutions.Select(resolution => new Resolution 
        { width = resolution.width, height = resolution.height }).Distinct().ToArray();
        //only selects the distinct resolutions without the refresh rates

        resDropdown.ClearOptions();

        List<string> resOptions = new List<string>();

        int currentResolution=0;
        for (int i = 0; i < resolutions.Length; i++)
        { 
            string option = resolutions[i].width + "x" + resolutions[i].height;
            resOptions.Add(option);

            if(resolutions[i].width== PlayerPrefs.GetInt("ResWidth")
                && resolutions[i].height== PlayerPrefs.GetInt("ResHeight"))
            {
                currentResolution = i;
            }
        }
        resDropdown.AddOptions(resOptions);
        resDropdown.value = currentResolution;
        resDropdown.RefreshShownValue();

        if (PlayerPrefs.GetInt("IsFullscreen") == 1)
            fullscreenToggle.isOn = true; 
        else
            fullscreenToggle.isOn = false;

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume ()
    {
        Cursor.visible = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        GameIsPaused = false;
    }
    void Pause ()
    {
        Cursor.visible = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

    }

    public void SetVolume(float volume)
    {
        masterMixer.SetFloat("Volume", Mathf.Log10(volume) * 20);
    }

    public void SetResolution(int resolutionIndex)
    {
        PlayerPrefs.SetInt("ResWidth", resolutions[resolutionIndex].width);
        PlayerPrefs.SetInt("ResHeight", resolutions[resolutionIndex].height);
        Screen.SetResolution(PlayerPrefs.GetInt("ResWidth"), PlayerPrefs.GetInt("ResHeight"), Screen.fullScreen);
    }
    public void SetFullscreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
        if(isFullScreen)
        PlayerPrefs.SetInt("IsFullscreen", 1);
        else
            PlayerPrefs.SetInt("IsFullscreen", 0);
    }
}
