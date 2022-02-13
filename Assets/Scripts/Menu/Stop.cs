using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stop : MonoBehaviour
{
    public List<AudioSource> stop;
    public Fall fall;

    private void OnMouseDown()
    {
        if (fall.enabled)
        {
            StartCoroutine(SayStop());
        }
    }

    IEnumerator SayStop()
    {
        int i = Random.Range(0, 3);
        stop[i].Play();
        yield return new WaitForSeconds(0.3f);
    }


}
