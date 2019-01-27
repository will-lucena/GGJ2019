using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{

    [SerializeField] GameObject credits;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadCredits()
    {
        credits.active = true;
    }

    public void LoadMenu()
    {
        credits.active = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
