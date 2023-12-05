using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class UIManager6 : MonoBehaviour
{
    public GameObject popUpPanel6;
    public InputField inputField6;
    private bool hasCollidedWithTrigger = false;

    void Start()
    {
        if (popUpPanel6 != null)
        {
            popUpPanel6.SetActive(false);
        }

        // event listener
        if (inputField6 != null)
        {
            inputField6.onEndEdit.AddListener((value) => OnEndEditInput6(value));
        }
    }


    public void OnEndEditInput6(string input)
{
    if (Input.GetKeyDown(KeyCode.Return))
    {
        Debug.Log("Input ended.");
    }

    if (input == "7463")
    {
        Debug.Log("Correct input!");
        SceneManager.LoadScene("complete3");
    }
    else
    {
        Debug.Log("Incorrect input. Try again.");
    }

    inputField6.text = "";
}


    public void ShowPopUp6()
    {
        if (popUpPanel6 != null)
        {
            popUpPanel6.SetActive(true);

            Canvas canvas = popUpPanel6.GetComponent<Canvas>();
            if (canvas != null)
            {
                canvas.sortingOrder = 1;
            }
        }
    }

    public void HidePopUp6()
    {
        if (popUpPanel6 != null)
        {
            popUpPanel6.SetActive(false);
        }
    }
}
