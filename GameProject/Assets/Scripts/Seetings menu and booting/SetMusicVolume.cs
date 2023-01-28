using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetMusicVolume : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider volumeSlider;
    private const string volumeKey = "Volume";

    private void Start()
    {
        volumeSlider.value= PlayerPrefs.GetFloat(volumeKey, 0.5f);
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    public void SetVolume(float volume)
    {
        GameObject musicPlayer = GameObject.Find("ThemeMusic");
        //for if sometihing happens and if it doesn't starts playing. 
        if (musicPlayer != null)
        {
            AudioSource musicSource = musicPlayer.GetComponent<AudioSource>();
            if (musicSource != null)
            {
                musicSource.volume = volume;
                //it is ready for saving the settings. 
                PlayerPrefs.SetFloat(volumeKey, volume);
                PlayerPrefs.Save();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
