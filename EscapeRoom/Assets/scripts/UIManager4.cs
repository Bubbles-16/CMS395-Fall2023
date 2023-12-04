using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class UIManager4 : MonoBehaviour
{
    public GameObject popUpPanel4;
    public InputField inputField4;
    private bool hasCollidedWithTrigger = false;

    void Start()
    {
        if (popUpPanel4 != null)
        {
            popUpPanel4.SetActive(false);
        }

        // event listener
        if (inputField4 != null)
        {
            inputField4.onEndEdit.AddListener((value) => OnEndEditInput4(value));
        }
    }


    public void OnEndEditInput4(string input)
{
    if (Input.GetKeyDown(KeyCode.Return))
    {
        Debug.Log("Input ended.");
    }

    if (input == "SWIMS" || input == "swims")
    {
        Debug.Log("Correct input!");
        HidePopUp4();
    }
    else
    {
        Debug.Log("Incorrect input. Try again.");
    }

    inputField4.text = "";
}


    public void ShowPopUp4()
    {
        if (popUpPanel4 != null)
        {
            popUpPanel4.SetActive(true);

            Canvas canvas = popUpPanel4.GetComponent<Canvas>();
            if (canvas != null)
            {
                canvas.sortingOrder = 1;
            }
        }
    }

    public void HidePopUp4()
    {
        if (popUpPanel4 != null)
        {
            popUpPanel4.SetActive(false);
        }
    }
}
