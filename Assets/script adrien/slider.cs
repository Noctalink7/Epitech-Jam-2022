using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

[RequireComponent(typeof (Slider))]
public class slider : MonoBehaviour
{
    Slider slide {
        get { return GetComponent<Slider>();}
    }
    public AudioMixer mixer;
    public new string name;
    // Start is called before the first frame update
    public void update_value_on_change(float value) {
        mixer.SetFloat(name, Mathf.Log(value) * 20f);
    }
}
