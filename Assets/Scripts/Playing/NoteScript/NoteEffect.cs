using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteEffect : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Color color;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        color = spriteRenderer.color;
        transform.localScale = new Vector3(60f, 60f, 60f);
    }

    // Update is called once per frame
    void Update()
    {
        if (color.a <= 0.0f) Destroy(gameObject);

        color.a -= Time.deltaTime * 3.0f;
        spriteRenderer.color = color;
    }
}
