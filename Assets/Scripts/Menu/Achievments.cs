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
        list.Father = false;
        list.Boss = false;
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
        if (list.Gorilla == true)
        {
            BoxText.text = text[2];
            image.sprite = sprites[2];
            StartCoroutine(ActivateBox());
            list.Gorilla = false;
        }
        if (list.Father == true)
        {
            BoxText.text = text[3];
            image.sprite = sprites[3];
            StartCoroutine(ActivateBox());
            list.Father = false;
        }
        if (list.Boss == true)
        {
            BoxText.text = text[4];
            image.sprite = sprites[4];
            StartCoroutine(ActivateBox());
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
