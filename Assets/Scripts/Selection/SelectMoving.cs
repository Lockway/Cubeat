using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectMoving : MonoBehaviour
{
    private AudioSource selectAudio;

    // Start is called before the first frame update
    void Start()
    {
        selectAudio = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Keypad8)|| Input.GetKeyDown(KeyCode.UpArrow))
        {
            selectAudio.Play();
            gameObject.transform.localPosition = new Vector3(480, 330, 0);
        }
        // Up
        if (Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            selectAudio.Play();
            gameObject.transform.localPosition = new Vector3(480, -330, 0);
        }
        // Down
        
        
        if (Mathf.Abs(gameObject.transform.localPosition.y) > 0.1f)
        {
            float v = gameObject.transform.localPosition.y * 3.0f;
            gameObject.transform.localPosition -= new Vector3(0, v * Time.deltaTime, 0);
        } // Moving
        
    }
}
