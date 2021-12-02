using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCUI : MonoBehaviour
{

    public Sprite Frown;
    public Sprite Smile;
    public Sprite SmileBig;
    public Sprite Neutral;
    private bool canTalk;
    public GameObject speechBubble;
    public GameObject NPCInterface;
    public Dictionary<int, string> DialogueTree = new Dictionary<int, string>();
    public Dictionary<int, Sprite> ImageTree = new Dictionary<int, Sprite>();
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
        DialogueTree[0] = "Yo! How's it goin?";
        DialogueTree[1] = "Name's Jack, nice to meet you.";
        DialogueTree[2] = "You're the drywall delivery guy, right? The dropoff point is directly to the east. You can just leave it in front of the office.";
        DialogueTree[3] = "The road is under construction, so you might have to jump over some stuff. Don't worry about breaking anything or eliminating any 'obstacles' along the way.";
        DialogueTree[4] = "The company will pay for the damage...";
        ImageTree[0] = Smile;
        ImageTree[1] = SmileBig;
        ImageTree[2] = Neutral;
        ImageTree[3] = Smile;
        ImageTree[4] = Frown;
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

            NPCInterface.GetComponent<NPCManager>().sendMessage(DialogueTree[DTtracker], ImageTree[DTtracker]); //send message from tree
            DTtracker++; //update to next message
            if (DTtracker >= DialogueTree.Count)
                DTtracker = DialogueTree.Count - 1; //-1 to not go beyond the bounds of the tree.
        }

    }
}
