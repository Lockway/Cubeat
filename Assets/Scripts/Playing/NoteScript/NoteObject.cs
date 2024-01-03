using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public bool hit;
    public bool canBePressed;
    public KeyCode keyToPress;
    public int noteTime;

    // Start is called before the first frame update
    void Start()
    {
        hit = false;
    }

    // Update is called once per frame
    void Update()
    {
        var musicTime = Mathf.RoundToInt(GameManager.instance.theMusic.time * 1000f);

        if (!canBePressed)
        {
            if (noteTime - GameSettings.JudgeTiming.Good <= musicTime && musicTime <= noteTime + GameSettings.JudgeTiming.Good)
            {
                canBePressed = true;
            }
        }
        else
        {
            if (noteTime + GameSettings.JudgeTiming.Good < musicTime)
            {
                canBePressed = false;
                if (!hit)
                {
                    GameManager.instance.NoteMiss();
                    GameManager.instance.judges[3]++;
                }
            }
        }
        
        if (Input.GetKeyDown(keyToPress))
        {
            if (canBePressed)
            {
                hit = true;
                gameObject.SetActive(false);

                if (noteTime - GameSettings.JudgeTiming.Good <= musicTime && musicTime <= noteTime - GameSettings.JudgeTiming.Perfect)
                {
                    Debug.Log("Early");
                    GameManager.instance.judgeLevel = 1;
                    GameManager.instance.judges[1]++;
                }
                else if (noteTime + GameSettings.JudgeTiming.Perfect <= musicTime && musicTime <= noteTime + GameSettings.JudgeTiming.Good)
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

    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.tag == "Activator")
    //     {
    //         canBePressed = true;
    //     }
    // }
    //
    // private void OnTriggerExit2D(Collider2D other)
    // {
    //     if (other.tag == "Activator")
    //     {
    //         canBePressed = false;
    //         if (!hit)
    //         {
    //             GameManager.instance.NoteMiss();
    //             GameManager.instance.judges[3]++;
    //         }
    //         
    //     }
    // }
}
