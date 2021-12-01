using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
// Game States

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {

        //Singleton method
        if (instance == null)
        {
            //First run, set the instance
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else if (instance != this)
        {
            //Instance is not the same as the one we have, destroy old one, and reset to newest one
            Destroy(instance.gameObject);
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        //if (instance == null)
        //{
        //    instance = this;
        //}
        //else
        //{
        //    Destroy(gameObject);
        //    return;
        //}
        //DontDestroyOnLoad(gameObject);
    }

    public void MainGame()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {

    }


}