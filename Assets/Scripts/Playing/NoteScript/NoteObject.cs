using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public bool canBePressed;
    public int keyNum;
    private KeyCode keyToPressMain, keyToPressSub;
    public int noteTime;
    
    public bool isLongNt;
    public int longNtEndTime;
    public bool isLongNtClicked;
    public int longNtTime;
    private int timeKeyDowned;
    private bool isKeyDowned;


    // Start is called before the first frame update
    void Start()
    {
        longNtTime = longNtEndTime - noteTime;
        keyToPressMain = KeyCode.Keypad1 + keyNum;
        keyToPressSub = GameManager.instance.mainToSubKey(keyNum);
    }

    // Update is called once per frame
    void Update()
    {
        if (isLongNtClicked)
        {
            if (Input.GetKey(keyToPressMain) || Input.GetKey(keyToPressSub))
            {
                if (!isKeyDowned)
                {
                    isKeyDowned = true;
                    timeKeyDowned = Mathf.RoundToInt(Time.time * 1000f);
                }
                else
                {
                    int elapsedTime = Mathf.RoundToInt(Time.time * 1000f) - timeKeyDowned;

                    if (elapsedTime >= longNtTime)
                    {
                        Debug.Log("Hit!");
                        int judgeLevel = 2;
                        GameManager.instance.judges[0]++;
                        ScoreManager.instance.judgeEffect(0);
                        GameManager.instance.NoteHit(-1, judgeLevel);

                        isLongNtClicked = false;
                        
                        Destroy(gameObject);
                    }
                }
            }
            else
            {
                Debug.Log("Missed!");
                GameManager.instance.judges[3]++;
                ScoreManager.instance.judgeEffect(3);
                GameManager.instance.NoteMiss(-1);

                isLongNtClicked = false;
                
                Destroy(gameObject);
            }
        }
    }
}
