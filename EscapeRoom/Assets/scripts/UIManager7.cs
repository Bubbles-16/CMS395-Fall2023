using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class UIManager7 : MonoBehaviour
{
    public GameObject popUpPanel7;
    public InputField inputField7;
    private bool hasCollidedWithTrigger = false;

    void Start()
    {
        if (popUpPanel7 != null)
        {
            popUpPanel7.SetActive(false);
        }

        // event listener
        if (inputField7 != null)
        {
            inputField7.onEndEdit.AddListener((value) => OnEndEditInput7(value));
        }
    }


    public void OnEndEditInput7(string input)
{
    if (Input.GetKeyDown(KeyCode.Return))
    {
        Debug.Log("Input ended.");
    }

    if (input == "duckling" || input == "DUCKLING")
    {
        Debug.Log("Correct input!");
        HidePopUp7();
    }
    else
    {
        Debug.Log("Incorrect input. Try again.");
    }

    inputField7.text = "";
}


    public void ShowPopUp7()
    {
        if (popUpPanel7 != null)
        {
            popUpPanel7.SetActive(true);

            Canvas canvas = popUpPanel7.GetComponent<Canvas>();
            if (canvas != null)
            {
                canvas.sortingOrder = 1;
            }
        }
    }

    public void HidePopUp7()
    {
        if (popUpPanel7 != null)
        {
            popUpPanel7.SetActive(false);
        }
    }
}
