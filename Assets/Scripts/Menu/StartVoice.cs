using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartVoice : MonoBehaviour
{
    private AudioSource voice1;
    public ChangeTitle change;
    public float time;

    // Start is called before the first frame update
    void Start()
    {
        voice1 = GetComponent<AudioSource>();
        StartCoroutine(PlayVoice());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator PlayVoice()
    {
        voice1.Play();
        yield return new WaitForSeconds(time);
        change.isActive = true;
    }
}
