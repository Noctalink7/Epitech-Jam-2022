using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public ChekList list;

    private void Start()
    {
        list.Gorilla = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            list.Gorilla = true;
            Destroy(gameObject);
        }
    }
}
