using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowJudge : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Color color;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        color = spriteRenderer.color;
        transform.localScale = new Vector3(50f, 50f, 50f);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localPosition.y > 220) Destroy(gameObject);
        transform.localPosition += new Vector3(0, Time.deltaTime * 300.0f, 0);

        color.a = (220 - transform.localPosition.y) / 100f;
        spriteRenderer.color = color;
    }
}
