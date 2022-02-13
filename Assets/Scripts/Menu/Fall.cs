using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour
{
    private int nb;
    private Rigidbody2D rb;
    private bool isActive = false;

    private void Start()
    {
        nb = 10;
        rb = GetComponent<Rigidbody2D>();
        isActive = true;
    }

    private void OnMouseDown()
    {
        if (isActive)
        {
            nb -= 1;
            StartCoroutine(Tremble());
            if (nb <= 0)
            {
                rb.gravityScale = 1;
            }
        }
    }

    IEnumerator Tremble()
    {
        for (int i = 0; i < 10; i++)
        {
            transform.localPosition += new Vector3(0f, 0.2f, 0f);
            yield return new WaitForSeconds(0.01f);
            transform.localPosition -= new Vector3(0f, 0.2f, 0f);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
