using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTitle : MonoBehaviour
{
    public Text title;
    public bool isActive;
    public List<Button> butttons;
    public float timeTalking;
    private Fall fall;
    public Fall fallStart;

    private void Start()
    {
        fall = GetComponent<Fall>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            StartCoroutine(ChangeText());
            isActive = false;
        }
    }

    IEnumerator ChangeText()
    {
        title.text = "Fina Fantasy";
        yield return new WaitForSeconds(0.1f);
        title.text = "Fin Fantasy";
        yield return new WaitForSeconds(0.1f);
        title.text = "Fi Fantasy";
        yield return new WaitForSeconds(0.1f);
        title.text = "F Fantasy";
        yield return new WaitForSeconds(0.1f);
        title.text = " Fantasy";
        yield return new WaitForSeconds(0.1f);
        title.text = "U Fantasy";
        yield return new WaitForSeconds(0.1f);
        title.text = "Ul Fantasy";
        yield return new WaitForSeconds(0.1f);
        title.text = "Ult Fantasy";
        yield return new WaitForSeconds(0.1f);
        title.text = "Ulti Fantasy";
        yield return new WaitForSeconds(0.1f);
        title.text = "Ultim Fantasy";
        yield return new WaitForSeconds(0.1f);
        title.text = "Ultima Fantasy";
        yield return new WaitForSeconds(0.1f);
        title.text = "Ultimat Fantasy";
        yield return new WaitForSeconds(0.1f);
        title.text = "Ultimate Fantasy";
        yield return new WaitForSeconds(24f);
        for (int i = 0; i != 3; i++)
            butttons[i].interactable = true;
        fall.enabled = true;
        fallStart.enabled = true;
    }
}
