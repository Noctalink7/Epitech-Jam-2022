using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YenAMarre : MonoBehaviour
{
    public ChekList list;
    public AudioSource voice;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (list.Boss)
        {
            list.Boss = false;
            StartCoroutine(Fini());
        }
    }

    IEnumerator Fini()
    {
        voice.Play();
        yield return new WaitForSeconds(10f);
        Application.Quit();
    }
}
