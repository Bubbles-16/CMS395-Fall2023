using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float displacement;
    Rigidbody2D player;
    Vector2 initial;
    public int sceneBuildIndex;
    public GameObject returnDoor;

    void Start()
    {
        returnDoor = GetComponent<GameObject>();
        player = GetComponent<Rigidbody2D>();
        initial = player.transform.localPosition;        
    }

    // Update is called once per frame
    void Update()
    {
        //Up = 'W' Key
        if (Input.GetKey(KeyCode.W))
            if(initial.y <= 4.50)
                initial.y = initial.y + displacement;
        //Down = 'S' Key
        if (Input.GetKey(KeyCode.S))
            if(initial.y >= -4.5)
                initial.y = initial.y - displacement;
        //Left = 'A' Key
        if (Input.GetKey(KeyCode.A))
            if(initial.x >= -8.45)
                initial.x = initial.x - displacement;
        //Right = 'D' Key
        if (Input.GetKey(KeyCode.D))
            if(initial.x <= 8.45)
                initial.x = initial.x + displacement;

        player.MovePosition(initial);
}

void OnTriggerEnter2D(Collider2D collision){

    
        if (collision.gameObject.CompareTag("trigger")){
            returnDoor.SetActive(false);
        }
        if (collision.gameObject.CompareTag("door1")){
            sceneBuildIndex = 1;
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }
        if (collision.gameObject.CompareTag("door2")){
            sceneBuildIndex = 2;
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }
        if (collision.gameObject.CompareTag("return door")){
            sceneBuildIndex = 0;
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }
        }
}