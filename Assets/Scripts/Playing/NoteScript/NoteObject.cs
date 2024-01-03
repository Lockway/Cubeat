using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public bool hit;
    public bool canBePressed;
    public KeyCode keyToPress;

    // Start is called before the first frame update
    void Start()
    {
        hit = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            if (canBePressed)
            {
                hit = true;
                gameObject.SetActive(false);

                if (transform.position.y > -3.5)
                {
                    Debug.Log("Early");
                    GameManager.instance.judgeLevel = 1;
                    GameManager.instance.judges[1]++;
                }
                else if (transform.position.y < -4.5)
                {
                    Debug.Log("Late");
                    GameManager.instance.judgeLevel = 1;
                    GameManager.instance.judges[2]++;
                }
                else
                {
                    Debug.Log("Perfect!");
                    GameManager.instance.judgeLevel = 2;
                    GameManager.instance.judges[0]++;
                }
                GameManager.instance.NoteHit();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = false;
            if (!hit)
            {
                GameManager.instance.NoteMiss();
                GameManager.instance.judges[3]++;
            }
            
        }
    }
}
