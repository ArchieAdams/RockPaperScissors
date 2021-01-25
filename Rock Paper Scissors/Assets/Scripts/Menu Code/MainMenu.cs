using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioMixer musicMixer;
    public AudioMixer sfxMixer;

    public Image mainMenuIcon;

    public Sprite Rock;
    public Sprite Paper;
    public Sprite Scissors;
    public List<Sprite> Icons = new List<Sprite>();


    public void Awake()
    {
        Icons.Add(Rock);
        Icons.Add(Paper);
        Icons.Add(Scissors);
        
        if ((PlayerPrefs.GetInt("key", -1234) == -1234))
        {
            Debug.Log("Using Presets");
            PlayerPrefs.SetInt("key", 0);
            //Game Options presets
            PlayerPrefs.SetFloat("Music Volume", -16.5f);
            PlayerPrefs.SetFloat("SFX Volume", 0f);

            PlayerPrefs.SetInt("Mode", 0);
        }
    }

    public void Start()
    {
        StartCoroutine(IconChanger());
        float musicVolume = PlayerPrefs.GetFloat("Music Volume");
        musicMixer.SetFloat("GameMusic", musicVolume);
        float sfxVolume = PlayerPrefs.GetFloat("SFX Volume");
        sfxMixer.SetFloat("GameSFX", sfxVolume);
    }

    IEnumerator IconChanger()
    {
        int index = 1;
        while (true)
        { 
            if (index == 3)
            {
                index = 0;
            }
            yield return new WaitForSeconds(1);
            mainMenuIcon.sprite = Icons[index];
            index++;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
