using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public enum Position
{
    Left,
    Center,
    Right,
}

public class NoteButton : MonoBehaviour
{
    

    public Position position;
    public Sprite defaultButton;
    public Sprite pushedButton;
    private Image displayImage;
    private bool isPushed;
    private List<KeyCode> pushedKey;

    private KeyCode[] leftButton = { KeyCode.Keypad1, KeyCode.Keypad4, KeyCode.Keypad7, KeyCode.X, KeyCode.S, KeyCode.W };
    private KeyCode[] centerButton = { KeyCode.Keypad2, KeyCode.Keypad5, KeyCode.Keypad8, KeyCode.C, KeyCode.D, KeyCode.E };
    private KeyCode[] rightButton = { KeyCode.Keypad3, KeyCode.Keypad6, KeyCode.Keypad9, KeyCode.V, KeyCode.F, KeyCode.R };
    private KeyCode[][] buttonArray;
    
    void Start()
    {
        displayImage = GetComponent<Image>();
        buttonArray = new[] { leftButton, centerButton, rightButton };
        pushedKey = new List<KeyCode>();
    }

    // Update is called once per frame
    void Update()
    {
        
        foreach (var button in buttonArray[(int)position])
        {
            if (Input.GetKeyDown(button))
            {
                if (pushedKey.Count == 0)
                {
                    displayImage.sprite = pushedButton;
                    isPushed = true;
                }

                if (!pushedKey.Contains(button))
                {
                    pushedKey.Add(button);
                }
            }
        }
        
        if (isPushed)
        {
            List<KeyCode> copyList = new List<KeyCode>(pushedKey);
            
            foreach (var key in copyList)
            {
                if (Input.GetKeyUp(key))
                {
                    pushedKey.Remove(key);
                    if (pushedKey.Count == 0)
                    {
                        displayImage.sprite = defaultButton;
                        isPushed = false;
                    }
                    
                }
            }
            
        }
        
    }
}