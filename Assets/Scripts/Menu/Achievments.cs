using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Achievments : MonoBehaviour
{
    public ChekList list;
    public GameObject box;
    public Text BoxText;
    public Image image; 
    public List<Sprite> sprites;
    public List<string> text;
    public AudioSource ping;

    // Start is called before the first frame update
    void Start()
    {
        list.Break = false;
        list.Start = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (list.Break == true)
        {
            BoxText.text = text[0];
            image.sprite = sprites[0];
            StartCoroutine(ActivateBox());
            list.Break = false;
        }
        if (list.Start == true)
        {
            BoxText.text = text[1];
            image.sprite = sprites[1];
            StartCoroutine(ActivateBox());
            list.Start = false;
        }
    }

    IEnumerator ActivateBox()
    {
        box.SetActive(true);
        ping.Play();
        yield return new WaitForSeconds(10f);
        box.SetActive(false);
    }
}
