using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BackToMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void BackToTheNightMenu()
    {
        SceneManager.LoadScene("NightMenu");
    }
    void Start()
    {

    }
}
