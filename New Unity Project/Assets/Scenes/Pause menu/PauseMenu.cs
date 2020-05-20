using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

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
        volumeSlider.value = value;

        resolutions = Screen.resolutions;
        resDropdown.ClearOptions();

        List<string> resOptions = new List<string>();

        int currentResolution = 0;
        for (int i = 0; i < resolutions.Length; i++)
        { 
            string option = resolutions[i].width + "x" + resolutions[i].height;
            resOptions.Add(option);

            if(resolutions[i].width==Screen.currentResolution.width
                &&resolutions[i].height==Screen.currentResolution.height)
            {
                currentResolution = i;
            }
        }
        resDropdown.AddOptions(resOptions);
        resDropdown.value = currentResolution;
        resDropdown.RefreshShownValue();

        fullscreenToggle.isOn = Screen.fullScreen;

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
        masterMixer.SetFloat("Volume", volume);
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution newResolution = resolutions[resolutionIndex];
        Screen.SetResolution(newResolution.width, newResolution.height, Screen.fullScreen);
    }
    public void SetFullscreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
}
