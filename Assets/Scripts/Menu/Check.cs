using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check : MonoBehaviour
{
    public ChekList list;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Start"))
        {
            list.lostStart = true;
        }
        else if (collider.CompareTag("Banner"))
            list.lostBanner = true;
        Destroy(collider.gameObject);
    }
}
