using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public void restart()
    {
        FindObjectOfType<AudioManager>().Play("Tap");
        SceneManager.LoadScene("Game",LoadSceneMode.Single);
        Time.timeScale = 1f;
    }
    public void menu()
    {
        FindObjectOfType<AudioManager>().Play("Tap");
        SceneManager.LoadScene("Start");
        Time.timeScale = 1f;
    }
    public void Playmenu()
    {
        FindObjectOfType<AudioManager>().Play("Tap");
        SceneManager.LoadScene("Game");
        Time.timeScale = 1f;
    }
    public void OnApplicationQuit()
    {
        Application.Quit();
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
