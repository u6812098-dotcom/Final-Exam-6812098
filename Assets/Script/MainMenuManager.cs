using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void LoadMadDriver()
    {
        SceneManager.LoadScene("Prototype 1");
    }
    public void LoadFlyLikeABird()
    {
        SceneManager.LoadScene("Challenge 1");
    }
    public void LoadSumo()
    {
        SceneManager.LoadScene("Prototype 4");
    }
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game Exited");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
