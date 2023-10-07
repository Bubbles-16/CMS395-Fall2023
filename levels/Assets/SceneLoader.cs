using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    public void LoadScene1()
    {
        SceneManager.LoadScene("Level2");
    }

    public void LoadScene2()
    {
        SceneManager.LoadScene("Level3");
    }

    public void LoadScene3()
    {
        SceneManager.LoadScene("Level4");
    }

    public void LoadScene4()
    {
        SceneManager.LoadScene("Level5");
    }

    public void LoadScene5()
    {
        SceneManager.LoadScene("MainMenu");
    }

}