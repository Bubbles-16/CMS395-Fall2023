using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{

    CircleCollider2D key;
    // Start is called before the first frame update
    void Start()
    {
        key = GetComponent<CircleCollider2D>();
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.gameObject.CompareTag("player"))
    {
        Invoke("DeactivateGameObject", 2f);
    }
}

void DeactivateGameObject()
{
    gameObject.SetActive(false);
}
}
