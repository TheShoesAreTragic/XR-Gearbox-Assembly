using UnityEngine;
using UnityEngine.SceneManagement; // Needed for scene loading

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string newSceneName = "VR_Training_Sim"; // Name of the scene to load
    // This function will be called by the Start button
    public void StartGame()
    {
        // Replace "GameScene" with the actual name of your scene
        SceneManager.LoadScene(newSceneName);
    }
    // Optional: a Quit button
    public void QuitGame()
    {
        Debug.Log("Game is quitting...");
        Application.Quit();
    }
}

