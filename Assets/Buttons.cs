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
        credits.SetActive(true);
    }

    public void LoadMenu()
    {
        credits.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
