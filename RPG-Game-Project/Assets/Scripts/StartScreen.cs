using UnityEngine;
using UnityEngine.SceneManagement;
//This imports the scene management library.

public class StartScreen : MonoBehaviour
{
    public void StartGame()
        //Void makes sure that no value needs to be returned, just run a taks and end.
    {
        Debug.Log("StartGame() called");
        //This prints whats in the "" if the code runs properly. Just used to check if the codes working

        SceneManager.LoadScene("MainScene");
        //SceneManager is apart of unity's scene management system. LoadScene tell unity to load the scene instad of the "".
    }
}