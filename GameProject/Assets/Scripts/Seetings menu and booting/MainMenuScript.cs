using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    // it may be better to do this with build index. 
    
    public void PlayGame()
    {

    }

    public void Settings()
    {
        SceneManager.LoadScene("Settingspage");

    }

    public void Quit()
    {
        Application.Quit();
    }    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
