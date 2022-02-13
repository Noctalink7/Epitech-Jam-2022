using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyFather : MonoBehaviour
{
    public AudioSource Voice;
    public ChekList list;
    private bool trigger;
    public PlayerMovement player;

    // Start is called before the first frame update
    void Start()
    {
        trigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        Diag();
    }

    private void Diag()
    {
        if (trigger)
        {
            Voice.Play();
            StartCoroutine(ActivateTime(17f));
            trigger = false;
        }
    }

    IEnumerator ActivateTime(float time)
    {
        yield return new WaitForSeconds(time);
        list.Father = true;
        yield return new WaitForSeconds(16f);
        player.currentState = PlayerState.idle;
        Destroy(gameObject);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            player.currentState = PlayerState.interact;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            trigger = true;
    }
}
