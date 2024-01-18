using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{
    public bool sound;
    public float outside;
    public float inside;

    private bool fadein;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        fadein = true;
        audioSource = GetComponent<AudioSource>();
        transform.localPosition = new Vector3(outside, 0, -9000f);
    }

    // Update is called once per frame
    void Update()
    {
        if (fadein)
        {
            if (sound) audioSource.Play();
            fadein = false;
        }

        if (transform.localPosition.x < inside)
        {
            transform.localPosition += new Vector3(Time.deltaTime * 4000f, 0, 0);
        }
    }
}
