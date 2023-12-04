using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class UIManager5 : MonoBehaviour
{
    public GameObject popUpPanel5;
    public InputField inputField5;
    private bool hasCollidedWithTrigger = false;

    void Start()
    {
        if (popUpPanel5 != null)
        {
            popUpPanel5.SetActive(false);
        }

        // event listener
        if (inputField5 != null)
        {
            inputField5.onEndEdit.AddListener((value) => OnEndEditInput5(value));
        }
    }


    public void OnEndEditInput5(string input)
{
    if (Input.GetKeyDown(KeyCode.Return))
    {
        Debug.Log("Input ended.");
    }

    if (input == "4860")
    {
        Debug.Log("Correct input!");
        SceneManager.LoadScene("complete2");
    }
    else
    {
        Debug.Log("Incorrect input. Try again.");
    }

    inputField5.text = "";
}


    public void ShowPopUp5()
    {
        if (popUpPanel5 != null)
        {
            popUpPanel5.SetActive(true);

            Canvas canvas = popUpPanel5.GetComponent<Canvas>();
            if (canvas != null)
            {
                canvas.sortingOrder = 1;
            }
        }
    }

    public void HidePopUp5()
    {
        if (popUpPanel5 != null)
        {
            popUpPanel5.SetActive(false);
        }
    }
}
