using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Sign : MonoBehaviour
{
    public GameObject diagBox;
    public PlayerMovement player;
    public Text diagText;
    public string dialog;
    public bool inRange;
    public bool isBad;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && inRange)
        {
            if(diagBox.activeInHierarchy)
            {
                diagBox.SetActive(false);
                player.currentState = PlayerState.idle;
                if (isBad)
                    SceneManager.LoadScene("combat_turn");
            }
            else
            {
                diagBox.SetActive(true);
                diagText.text = dialog;
                player.currentState = PlayerState.interact;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            inRange = false;
            diagBox.SetActive(false);
        }
    }
}
