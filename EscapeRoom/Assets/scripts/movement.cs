using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{
    public float displacement;
    private Rigidbody2D player;
    private Vector2 initial;
    public int sceneBuildIndex;
    public GameObject returnDoor;
    private bool hasCollidedWithTrigger;
    private UIManager uiManager;
    private UIManager2 uiManager2;

    void Start()
{
    returnDoor = GetComponent<GameObject>();
    player = GetComponent<Rigidbody2D>();
    initial = player.transform.localPosition;

    uiManager = FindObjectOfType<UIManager>();
    if (uiManager == null)
    {
        Debug.LogError("UIManager not found in the scene.");
    }
    else
    {
        Debug.Log("UIManager found successfully.");
    }

    uiManager2 = FindObjectOfType<UIManager2>();
    if (uiManager2 == null)
    {
        Debug.LogError("UIManager2 not found in the scene.");
    }
    else
    {
        Debug.Log("UIManager2 found successfully.");
    }
}

    void Update()
    {
        // up = 'W' key
        if (Input.GetKey(KeyCode.W) && initial.y <= 4.5)
            initial.y = initial.y + displacement;
        // down = 'S' key
        if (Input.GetKey(KeyCode.S) && initial.y >= -4.5)
            initial.y = initial.y - displacement;
        // left = 'A' key
        if (Input.GetKey(KeyCode.A) && initial.x >= -8.45)
            initial.x = initial.x - displacement;
        // right = 'D' key
        if (Input.GetKey(KeyCode.D) && initial.x <= 8.45)
            initial.x = initial.x + displacement;

        player.MovePosition(initial);
}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("trigger"))
        {
            uiManager2.ShowPopUp2();
            hasCollidedWithTrigger = true;
            Debug.LogError("UIManager2 pop up popped up.");
        }

        if (collision.gameObject.CompareTag("return door") && hasCollidedWithTrigger == true)
        {
            if (uiManager != null)
            {
                uiManager.ShowPopUp();
                Debug.LogError("pop up popped up.");
            }
            else
            {
                Debug.LogError("UIManager is null.");
            }
        }
    if (collision.gameObject.CompareTag("door1"))
    {
        SceneManager.LoadScene("room1");
    }
    if (collision.gameObject.CompareTag("door2"))
    {
        SceneManager.LoadScene("room2");
    }
    if (collision.gameObject.CompareTag("door3"))
    {
        SceneManager.LoadScene("room3");
    }
    
}

}

