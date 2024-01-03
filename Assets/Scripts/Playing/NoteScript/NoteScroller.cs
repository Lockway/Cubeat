using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteScroller : MonoBehaviour
{
    public float beatTempo;
    public bool hasStarted;
    

    // Start is called before the first frame update
    void Start()
    {
        beatTempo /= 60f;
        beatTempo *= GameSettings.HighSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            if (Input.anyKeyDown)
            {
                hasStarted = true;
            }
        }
        else
        {
            //transform.position -= new Vector3(0f, beatTempo * Time.deltaTime, 0f);
            transform.localPosition -= new Vector3(0f, GameSettings.HighSpeed * Time.deltaTime * 100, 0f);
        }
    }
}
