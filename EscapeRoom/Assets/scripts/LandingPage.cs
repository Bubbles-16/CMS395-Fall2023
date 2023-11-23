using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LandingPage : MonoBehaviour
{
    public Button startButton; // Assign the "Start" button in the Inspector.

    private void Start()
    {
        // Add a click event listener to the button.
        startButton.onClick.AddListener(StartGame);
    }

    private void StartGame()
    {
        // Load the "lobby" scene when the button is clicked.
        SceneManager.LoadScene("lobby");
    }
}
