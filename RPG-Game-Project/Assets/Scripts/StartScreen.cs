using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log("StartGame() called"); // This will print to the Console if the function is called
        SceneManager.LoadScene("MainScene");
    }
}