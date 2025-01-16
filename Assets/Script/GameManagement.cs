using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagement : Singleton<GameManagement>
{
    
    public GameObject Menu;
    public void EndGame()
    {
        //if (!finishedFlagg)
        //{
        Menu.SetActive(true);
        ScoreSystem.Instance.CalculateScore();
        //    finishedFlagg = false ;
        //}
    }
    public void StartGame()
    {
        Menu.SetActive(false);
        Timer.Instance.StartTimer();
    }
    private void Start()
    {
        
        StartGame();
    }
    private void Update()
    {
       
    }
    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void LoadNextScene()
    {
        // Get the current scene's name
        string currentSceneName = SceneManager.GetActiveScene().name;

        // Determine the next scene's name
        string nextSceneName = GetNextSceneName(currentSceneName);

        // Load the next scene
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogError("Next scene name is invalid or undefined!");
        }
    }

    private string GetNextSceneName(string currentSceneName)
    {
        // Map scenes to their next scenes
        switch (currentSceneName)
        {
            case "Tutorial1":
                return "Tutorial2";
            case "Tutorial2":
                return "Tutorial3";
            case "Tutorial3":
                return "Menu";
            case "Scene1":
                return "Scene2";
            case "Scene2":
                return "Scene3";
            case "Scene3":
                return "Scene4";
            case "Scene4":
                return "Scene5";
            case "Scene5":
                return "Menu";
            default:
                return null; // Return null if there is no next scene
        }
    }
}
