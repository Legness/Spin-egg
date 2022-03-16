using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
   // public bool enabled;
    public float volume;
    public GameObject On3;
    public GameObject On2;
    public GameObject On1;
    public GameObject Off;
    public AudioMixerGroup Mixer;
    public GameObject Ad;
    public GameObject panel;
    public GameObject PanelSett;
    public void StartSc()
    {
       // Ad.SetActive(true);
        SceneManager.LoadScene(1);
       // Mixer.audioMixer.SetFloat("MasterVolume", -80);

    }
    void Start()
    {
       /* Ad.SetActive(false);
        volume = PlayerPrefs.GetFloat("volume");
        Mixer.audioMixer.SetFloat("MasterVolume", volume);
        switch (volume)
        {
            case 0: On1.SetActive(true); On2.SetActive(true); On3.SetActive(true); Off.SetActive(false); break;
            case -20: On1.SetActive(true); On2.SetActive(true); On3.SetActive(false); Off.SetActive(false); break;
            case -40: On1.SetActive(true); On2.SetActive(false); On3.SetActive(false); Off.SetActive(false); break;
            case -80: On1.SetActive(false); On2.SetActive(false); On3.SetActive(false); Off.SetActive(true); break;
        }*/
    }
    public void Texit()
    {
        panel.SetActive(true);
    }
    public void Bexit()
    {
        panel.SetActive(false);
    }
    public void exit()
    {
        Application.Quit();
    }
    public void Skin()
    {
        SceneManager.LoadScene(2);
    }
    public void Settings()
    {
        Time.timeScale = 0f;
        PanelSett.SetActive(true);
    }
    public void SettingsOff()
    {
        Time.timeScale = 1f;
        PanelSett.SetActive(false);
    }
   /* public void Volume()
    {
        switch (volume)
        {
            case 0: On1.SetActive(true); On2.SetActive(true); On3.SetActive(false); Off.SetActive(false); volume = -20; break;
            case -20: On1.SetActive(true); On2.SetActive(false); On3.SetActive(false); Off.SetActive(false); volume = -40; break;
            case -40: On1.SetActive(false); On2.SetActive(false); On3.SetActive(false); Off.SetActive(true); volume = -80; break;
            case -80: On1.SetActive(true); On2.SetActive(true); On3.SetActive(true); Off.SetActive(false); volume = 0; break;

        }
        Mixer.audioMixer.SetFloat("MasterVolume", volume);
        PlayerPrefs.SetFloat("volume", volume);

    }*/



}
