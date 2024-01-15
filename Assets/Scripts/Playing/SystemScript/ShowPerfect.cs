using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPerfect : MonoBehaviour
{
    public int option;

    private bool doEffect;
    private bool effectDone;
    private float delayer;

    private Image img;
    private Color color;
    private AudioSource impact;
    private ParticleSystem particle;

    // Start is called before the first frame update
    void Start()
    {
        doEffect = false;
        effectDone = false;
        delayer = 0.0f;

        if (option == 1 || option == 2)
        {
            impact = gameObject.GetComponent<AudioSource>();
            img = gameObject.GetComponent<Image>();
            color = img.color;
        }
        else if (option == 3)
        {
            particle = gameObject.GetComponent<ParticleSystem>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (option == 0)
        {
            if (GameManager.instance.currentCombo == GameManager.instance.maxCombo)
            {
                Destroy(gameObject);
            }
            else if (GameManager.instance.songEnd) GameManager.instance.playingEnd = true;
        } // Combo Tab
        else if (option < 3)
        {
            if (GameManager.instance.currentCombo == GameManager.instance.maxCombo)
            {
                if (!doEffect && option == 1 && GameManager.instance.currentScore == 1000000)
                {
                    doEffect = true;
                    impact.Play();
                }
                if (!doEffect && option == 2 && GameManager.instance.currentScore != 1000000)
                {
                    doEffect = true;
                    impact.Play();
                }

                if (!doEffect) Destroy(gameObject);

                if (delayer < 0.2f) delayer += Time.deltaTime;
                else if (!effectDone)
                {
                    if (color.a < 1.0f)
                    {
                        color = img.color;
                        color.a += Time.deltaTime * 2.0f;
                        img.color = color;
                    }

                    if (gameObject.transform.localScale.x > 1.0f)
                    {
                        gameObject.transform.localScale -= new Vector3(Time.deltaTime * 3.0f, Time.deltaTime * 3.0f, 0);
                    }
                    else effectDone = true;
                }
                else
                {
                    if (delayer < 1.5f) delayer += Time.deltaTime;
                    else GameManager.instance.playingEnd = true;
                }

            }
        } // Colorful Play or Full Combo
        else if (option == 3)
        {
            if (!doEffect && GameManager.instance.currentCombo == GameManager.instance.maxCombo) doEffect = true;

            if (doEffect && !effectDone)
            {
                if (delayer < 0.2f) delayer += Time.deltaTime;
                else
                {
                    particle.Play();
                    effectDone = true;
                }
            }
            if (GameManager.instance.playingEnd) Destroy(gameObject);
        }
    }
}
