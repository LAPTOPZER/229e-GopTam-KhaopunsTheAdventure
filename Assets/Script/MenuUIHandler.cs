using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{

    public void StartGame()
    {
        if (Inventory.Instance != null)
        {
            Destroy(Inventory.Instance.gameObject);
        }

        Time.timeScale = 1f;
        SceneManager.LoadScene("Game");
    }

    //public void RestartGame()
    //{
    //    if (Inventory.Instance != null)
    //    {
    //        Destroy(Inventory.Instance.gameObject);
    //    }

    //    Time.timeScale = 1f;
    //    SceneManager.LoadScene("Game");
    //}

    public void Credit()
    {
        SceneManager.LoadScene("Credit");
    }

    public void BacktoMainMenu()
    {
        if (Inventory.Instance != null)
        {
            Destroy(Inventory.Instance.gameObject);
        }

        SceneManager.LoadScene("MainMenu");
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene("HowToPlay");
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif

    }

}
