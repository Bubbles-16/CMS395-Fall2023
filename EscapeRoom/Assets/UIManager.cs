using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class UIManager : MonoBehaviour
{
    public GameObject popUpPanel;
    public InputField inputField;
    private bool hasCollidedWithTrigger = false;

    void Start()
    {
        if (popUpPanel != null)
        {
            popUpPanel.SetActive(false);
        }

        // event listener
        if (inputField != null)
        {
            inputField.onEndEdit.AddListener((value) => OnEndEditInput(value));
        }
    }

    public void OnEndEditInput(string input)
{
    if (Input.GetKeyDown(KeyCode.Return))
    {
        Debug.Log("Input ended.");
    }

    if (input == "7193")
    {
        Debug.Log("Correct input!");
        SceneManager.LoadScene("room2");
    }
    else
    {
        Debug.Log("Incorrect input. Try again.");
    }

    inputField.text = "";
}


    public void ShowPopUp()
    {
        if (popUpPanel != null)
        {
            popUpPanel.SetActive(true);

            Canvas canvas = popUpPanel.GetComponent<Canvas>();
            if (canvas != null)
            {
                canvas.sortingOrder = 1;
            }
        }
    }

    public void HidePopUp()
    {
        if (popUpPanel != null)
        {
            popUpPanel.SetActive(false);
        }
    }
}
