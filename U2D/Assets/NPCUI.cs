using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCUI : MonoBehaviour
{
    private bool canTalk;
    public GameObject speechBubble;
    public GameObject NPCInterface;
    public Dictionary<int, string> DialogueTree = new Dictionary<int, string>();
    public int DTtracker = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Vector3 work = new Vector3(1, 1, 1);
            speechBubble.transform.localScale = work;
            canTalk = true;
        }
            
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            Vector3 work = new Vector3(0, 0, 0);       
            speechBubble.transform.localScale = work;
            canTalk = false;
            if (NPCInterface.GetComponent<NPCManager>().isToggled) //close interface when leaving
                NPCInterface.GetComponent<NPCManager>().toggleDisplay();
        }
    }

    private void Awake()
    {
        DialogueTree[0] = "Yo! Hows it goin?";
        DialogueTree[1] = "Names Jack, nice to meet you.";
        DialogueTree[2] = "You're the drywall delivery guy right? The dropoff point is directly to the east. You can just leave it in front of the office.";
        DialogueTree[3] = "The road is under construction so you might have to jump over some stuff. Dont worry about breaking anything or eliminating any 'obsticles' along the way.";
        //DialogueTree[4] = "The company will pay for the damage.";
    }

    // Start is called before the first frame update
    void Start()
    {
        canTalk = false;      
    }

    // Update is called once per frame
    void Update()
    {
        if (canTalk == true && Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            if (!NPCInterface.GetComponent<NPCManager>().isToggled) //show the NPC menu if it is not shown
                NPCInterface.GetComponent<NPCManager>().toggleDisplay();

            NPCInterface.GetComponent<NPCManager>().sendMessage(DialogueTree[DTtracker]); //send message from tree
            DTtracker++; //update to next message
            if (DTtracker >= DialogueTree.Count)
                DTtracker = DialogueTree.Count - 1; //-1 to not go beyond the bounds of the tree.
        }

    }
}
