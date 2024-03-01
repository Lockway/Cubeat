using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public bool canBePressed;
    public int keyNum;
    private KeyCode keyToPressMain, keyToPressSub;
    public int noteTime;
    // Common
    
    public bool isLongNt;
    public bool isLongNtClicked;
    public int longNtEndTime;
    private bool isLongNtPassed;
    // LongNote


    // Start is called before the first frame update
    void Start()
    {
        keyToPressMain = KeyCode.Keypad1 + keyNum;
        keyToPressSub = GameManager.instance.mainToSubKey(keyNum);
    }

    // Update is called once per frame (Only for longNote)
    void Update()
    {
        if (isLongNtClicked)
        {
            var musicTime = Mathf.RoundToInt(GameManager.instance.theMusic.time * 1000f);

            if (GameSettings.GameMode == 5)
            {
                if (longNtEndTime <= musicTime)
                {
                    GameManager.instance.judges[0]++;
                    ScoreManager.instance.judgeEffect(0);
                    GameManager.instance.NoteHit(-1, 2);

                    isLongNtClicked = false;
                    GameManager.instance.HitEffect(keyNum % 3);

                    Destroy(gameObject);
                }
                return;
            }   // Auto Play

            if (Input.GetKey(keyToPressMain) || Input.GetKey(keyToPressSub))
            {
                //if (musicTime >= longNtEndTime)
                if (!isLongNtPassed && longNtEndTime - GameSettings.JudgeTiming.Good <= musicTime && musicTime < longNtEndTime)
                {
                    isLongNtPassed = true;
                }
                else if (longNtEndTime <= musicTime)
                {
                    GameManager.instance.judges[0]++;
                    ScoreManager.instance.judgeEffect(0);
                    GameManager.instance.NoteHit(-1, 2);

                    isLongNtClicked = false;
                    GameManager.instance.HitEffect(keyNum % 3);

                    Destroy(gameObject);
                }
            }
            else
            {
                if (isLongNtPassed)
                {
                    GameManager.instance.judges[0]++;
                    ScoreManager.instance.judgeEffect(0);
                    GameManager.instance.NoteHit(-1, 2);
                    
                    isLongNtClicked = false;
                    GameManager.instance.HitEffect(keyNum % 3);

                    Destroy(gameObject);
                }
                else
                {
                    GameManager.instance.judges[3]++;
                    ScoreManager.instance.judgeEffect(3);
                    GameManager.instance.NoteMiss(-1);

                    isLongNtClicked = false;
                
                    Destroy(gameObject);
                }
            }
        }
    }
}
