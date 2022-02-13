using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceAction : MonoBehaviour
{
    public ChekList list;
    public GameObject Start2;
    public GameObject Banner2;

    // Start is called before the first frame update
    void Start()
    {
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
        if (list.lostStart)
            Start2.SetActive(true);
    }
    private void PutNewbanner()
    {
        if (list.lostBanner)
            Banner2.SetActive(true);
    }


}
