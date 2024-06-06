using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("game");

    }

    public void QuitGame()
    {
      Application.Quit();

    } 

    public void ReturnMenu()
    {
        SceneManager.LoadScene("menu");

    }

    public void OpenCredits()
    {
        SceneManager.LoadScene("credits");

    }
}