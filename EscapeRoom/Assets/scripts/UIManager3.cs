using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class UIManager3 : MonoBehaviour
{
    public GameObject popUpPanel3;
    public InputField inputField3;
    private bool hasCollidedWithTrigger = false;

    void Start()
    {
        if (popUpPanel3 != null)
        {
            popUpPanel3.SetActive(false);
        }

        // event listener
        if (inputField3 != null)
        {
            inputField3.onEndEdit.AddListener((value) => OnEndEditInput3(value));
        }
    }


    public void OnEndEditInput3(string input)
{
    if (Input.GetKeyDown(KeyCode.Return))
    {
        Debug.Log("Input ended.");
    }

    if (input == "FEATHER")
    {
        Debug.Log("Correct input!");
        HidePopUp3();
    }
    else
    {
        Debug.Log("Incorrect input. Try again.");
    }

    inputField3.text = "";
}


    public void ShowPopUp3()
    {
        if (popUpPanel3 != null)
        {
            popUpPanel3.SetActive(true);

            Canvas canvas = popUpPanel3.GetComponent<Canvas>();
            if (canvas != null)
            {
                canvas.sortingOrder = 1;
            }
        }
    }

    public void HidePopUp3()
    {
        if (popUpPanel3 != null)
        {
            popUpPanel3.SetActive(false);
        }
    }
}
