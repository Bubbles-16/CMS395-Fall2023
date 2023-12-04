using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMovement1 : MonoBehaviour
{
    public float displacement;
    private Rigidbody2D player;
    private Vector2 initial;
    public int sceneBuildIndex;
    public GameObject returnDoor;
    private bool hasCollidedWithTrigger;
    private bool hasCollidedWithTrigger2;
    private UIManager5 uiManager5;
    private UIManager3 uiManager3;
    private UIManager4 uiManager4;
    public Animator animator;

    void Start()
{
    returnDoor = GetComponent<GameObject>();
    player = GetComponent<Rigidbody2D>();
    initial = player.transform.localPosition;

    uiManager5 = FindObjectOfType<UIManager5>();
    if (uiManager5 == null)
    {
        Debug.LogError("UIManager5 not found in the scene.");
    }
    else
    {
        Debug.Log("UIManager5 found successfully.");
    }

    uiManager4 = FindObjectOfType<UIManager4>();
    if (uiManager4 == null)
    {
        Debug.LogError("UIManager4 not found in the scene.");
    }
    else
    {
        Debug.Log("UIManager4 found successfully.");
    }

    uiManager3 = FindObjectOfType<UIManager3>();
    if (uiManager3 == null)
    {
        Debug.LogError("UIManager3 not found in the scene.");
    }
    else
    {
        Debug.Log("UIManager3 found successfully.");
    }
}

    void Update()
    {
        // up = 'W' key
        if (Input.GetKey(KeyCode.W) && initial.y <= 4.5) {
            initial.y = initial.y + displacement;
            animator.SetFloat("speed", 1);
        }
        // down = 'S' key
        else if (Input.GetKey(KeyCode.S) && initial.y >= -4.5) {
            initial.y = initial.y - displacement;
            animator.SetFloat("speed", 1);
            }
        // left = 'A' key
        else if (Input.GetKey(KeyCode.A) && initial.x >= -8.45) {
            initial.x = initial.x - displacement;
            animator.SetFloat("speed", 1);
        }
        // right = 'D' key
        else if (Input.GetKey(KeyCode.D) && initial.x <= 8.45) {
            initial.x = initial.x + displacement;
            animator.SetFloat("speed", 1);
        }
        else{
            animator.SetFloat("speed", 0);
    }

        player.MovePosition(initial);
}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("trigger"))
        {
            uiManager3.ShowPopUp3();
            hasCollidedWithTrigger = true;
            Debug.LogError("UIManager3 pop up popped up.");
        }

        if (collision.gameObject.CompareTag("trigger2"))
        {
            uiManager4.ShowPopUp4();
            hasCollidedWithTrigger2 = true;
            Debug.LogError("UIManager4 pop up popped up.");
        }

        if (collision.gameObject.CompareTag("return door") && hasCollidedWithTrigger == true && hasCollidedWithTrigger2 == true)
        {
            if (uiManager5 != null)
            {
                uiManager5.ShowPopUp5();
                Debug.LogError("pop up popped up.");
            }
            else
            {
                Debug.LogError("UIManager5 is null.");
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
    if (collision.gameObject.CompareTag("door4"))
    {
        SceneManager.LoadScene("room4");
    }
    if (collision.gameObject.CompareTag("door5"))
    {
        SceneManager.LoadScene("room5");
    }
}

}

