using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{
    public float displacement;
    Rigidbody2D player;
    Vector2 initial;
    public int sceneBuildIndex;
    public GameObject returnDoor;
    private bool hasCollidedWithTrigger = false;

    void Start()
    {
        returnDoor = GetComponent<GameObject>();
        player = GetComponent<Rigidbody2D>();
        initial = player.transform.localPosition;
    }

    void Update()
    {
        // up = 'W' key
        if (Input.GetKey(KeyCode.W))
            if (initial.y <= 4.5)
                initial.y = initial.y + displacement;
        // down = 'S' key
        if (Input.GetKey(KeyCode.S))
            if (initial.y >= -4.5)
                initial.y = initial.y - displacement;
        // left = 'A' key
        if (Input.GetKey(KeyCode.A))
            if (initial.x >= -8.45)
                initial.x = initial.x - displacement;
        // right = 'D' key
        if (Input.GetKey(KeyCode.D))
            if (initial.x <= 8.45)
                initial.x = initial.x + displacement;

        player.MovePosition(initial);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("trigger")) {
            hasCollidedWithTrigger = true;
            returnDoor.SetActive(false);
        } if (collision.gameObject.CompareTag("return door") && hasCollidedWithTrigger) {
            sceneBuildIndex = 0;
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }
        if (collision.gameObject.CompareTag("door1")){
            SceneManager.LoadScene("room1");
        }
        if (collision.gameObject.CompareTag("door2")){
            SceneManager.LoadScene("room2");
        }
        if (collision.gameObject.CompareTag("door3")){
            SceneManager.LoadScene("room3");
        }
        if (collision.gameObject.CompareTag("door4")){
            SceneManager.LoadScene("room4");
        }
        if (collision.gameObject.CompareTag("door5")){
            SceneManager.LoadScene("room5");
        }
    }
}
