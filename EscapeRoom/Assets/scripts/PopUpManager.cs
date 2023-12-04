using UnityEngine;
using UnityEngine.UI;

public class PopUpManager : MonoBehaviour
{
    public GameObject popUpPanel;
    public InputField inputField;

    private void Start()
    {
        // Ensure the pop-up panel is initially inactive
        if (popUpPanel != null)
        {
            popUpPanel.SetActive(false);
        }
    }

    // Call this method to show the pop-up
    public void ShowPopUp()
    {
        if (popUpPanel != null)
        {
            // Activate the pop-up panel
            popUpPanel.SetActive(true);
            
            // Optionally, you can set the input field text to an empty string
            inputField.text = "";
        }
    }

    // Call this method to hide the pop-up
    public void HidePopUp()
    {
        if (popUpPanel != null)
        {
            // Deactivate the pop-up panel
            popUpPanel.SetActive(false);
        }
    }

    // Call this method to get the input from the input field
    public string GetInput()
    {
        // Return the text entered in the input field
        return inputField.text;
    }
}
