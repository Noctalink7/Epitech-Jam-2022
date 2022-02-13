using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceAction : MonoBehaviour
{
    public List<AudioSource> Voices;

    public ChekList list;
    public GameObject Start2;
    public GameObject Banner2;

    public List<bool> triggers;

    private bool isTalking;

    // Start is called before the first frame update
    void Start()
    {
        isTalking = false;
        list.isTalking = false;
        list.lostStart = false;
        list.lostBanner = false;
    }

    // Update is called once per frame
    void Update()
    {
        PutNewStart();
        PutNewbanner();
    }

    private void PutNewStart()
    {
        if (list.lostStart && triggers[0] && !isTalking)
        {
            Voices[0].Play();
            StartCoroutine(ActivateTime(8.5f, Start2));
            triggers[0] = false;
            list.Start = true;
        }
    }
    private void PutNewbanner()
    {
        if (list.lostBanner && triggers[1] && !isTalking)
        {
            Voices[1].Play();
            StartCoroutine(ActivateTime(19f, Banner2));
            triggers[1] = false;
            list.Break = true;
        }
    }

    IEnumerator ActivateTime(float time, GameObject gameObject)
    {
        isTalking = true;
        yield return new WaitForSeconds(time);
        gameObject.SetActive(true);
        isTalking = false;
    }
}
