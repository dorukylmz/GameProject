using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BootingScreen : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource musicSource;
    private const string volumeKey = "Volume";

    // i wan't to make 2 seperete screens for daytime and night time this is for it
    void Start()
    {
        musicSource.volume= PlayerPrefs.GetFloat(volumeKey, 0.5f);
        DontDestroyOnLoad(musicSource);
        DateTime currentTime = DateTime.Now;
        int currentHour = currentTime.Hour;

        if (currentHour >= 6 && currentHour < 18)
        {

            // open dayScene
            SceneManager.LoadScene("DayMenu");
        }
        else
        {
            // open nightScene
            SceneManager.LoadScene("NightMenu");
        }
    }
}
