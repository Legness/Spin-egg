using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class Skin : MonoBehaviour
{
    [SerializeField] public GameObject Egg;

    SelectedSkin.Data data = new SelectedSkin.Data();
    public int i;
    public float volume;
   // public AudioMixerGroup Mixer;
    public Sprite[] AllCharacters;

    private void Start()
    {

        volume = PlayerPrefs.GetFloat("volume");
        //Mixer.audioMixer.SetFloat("MasterVolume", volume);
        i = PlayerPrefs.GetInt("Skin");
        if (PlayerPrefs.HasKey("SaveGame"))
        {

            Egg.GetComponent<SpriteRenderer>().sprite = AllCharacters[i];

        }
        else
        {


            Egg.GetComponent<SpriteRenderer>().sprite = AllCharacters[0];
        }


    }

    public IEnumerator LoadSkin()
    {
        i = 0;

        while (AllCharacters[i].name != data.currentCharacter)
        {
            i++;
        }
        Egg.GetComponent<SpriteRenderer>().sprite = AllCharacters[i];
        yield return null;
    }

}
