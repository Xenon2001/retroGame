using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public AudioMixer masterMixer;
    public Slider volumeSlider;
    public Transform dropdownMenu;
    void Start()
    {
        float value;
        masterMixer.GetFloat("Volume", out value);
        volumeSlider.value = value;
        int quality = QualitySettings.GetQualityLevel();
        dropdownMenu.GetComponent<Dropdown>().value = quality;

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
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        GameIsPaused = false;
    }
    void Pause ()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

    }

    public void SetVolume(float volume)
    {
        masterMixer.SetFloat("Volume", volume);
    }
    public void SetQuality(int qualityLevel)
    {
        QualitySettings.SetQualityLevel(qualityLevel);
    }
}
