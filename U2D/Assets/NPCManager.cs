using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCManager : MonoBehaviour
{
    public Image NPCPortrait;
    public Text chatLog;
    public Text NPCName;
    public bool isToggled;

    //Typwriter style text
    public float textspeed = 0.05f; //how many seconds between characters. (Lower number = faster)
    private string currentText = "";

    public void sendMessage(string Message, Sprite Portrait = null)
    {
        //chatLog.text = Message;
        StartCoroutine(displayText(Message));
        if (Portrait != null)
            NPCPortrait.sprite = Portrait;
    }

    IEnumerator displayText(string Message)
    {
        for (int i = 0; i <= Message.Length; i++)
        {
            currentText = Message.Substring(0, i);
            chatLog.text = currentText;
            yield return new WaitForSeconds(textspeed);
        }
    }

    public void Start()
    {
        if (this.transform.localScale.x == 1)
            isToggled = true;
        else
            isToggled = false;
    }

    public void toggleDisplay()
    {
        if (this.transform.localScale.x == 0)
        {
            this.transform.localScale = new Vector3(1,1,1);
            isToggled = true;
        }
        else
        {
            this.transform.localScale = new Vector3(0, 0, 0);
            isToggled = false;
        }
            
    }
}
