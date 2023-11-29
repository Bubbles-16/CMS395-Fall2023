using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class UIManager2 : MonoBehaviour
{
    public GameObject popUpPanel2;
    public InputField inputField2;
    private bool hasCollidedWithTrigger = false;

    void Start()
    {
        if (popUpPanel2 != null)
        {
            popUpPanel2.SetActive(false);
        }

        // event listener
        if (inputField2 != null)
        {
            inputField2.onEndEdit.AddListener((value) => OnEndEditInput2(value));
        }
    }


    public void OnEndEditInput2(string input)
{
    if (Input.GetKeyDown(KeyCode.Return))
    {
        Debug.Log("Input ended.");
    }

    if (input == "3")
    {
        Debug.Log("Correct input!");
        HidePopUp2();
    }
    else
    {
        Debug.Log("Incorrect input. Try again.");
    }

    inputField2.text = "";
}


    public void ShowPopUp2()
    {
        if (popUpPanel2 != null)
        {
            popUpPanel2.SetActive(true);

            Canvas canvas = popUpPanel2.GetComponent<Canvas>();
            if (canvas != null)
            {
                canvas.sortingOrder = 1;
            }
        }
    }

    public void HidePopUp2()
    {
        if (popUpPanel2 != null)
        {
            popUpPanel2.SetActive(false);
        }
    }
}
