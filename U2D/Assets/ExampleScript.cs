using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleScript : MonoBehaviour
{

    public bool checkbox; //I'm a public variable! I'm visible in the inspector!
    public string textbox;

    private bool nonEditableCheckbox; //I'm a private variable. I'm only editable through script and not the inspector.
    private string nonEditableTextbox;

    // Start is called before the first frame update
    void Start()
    {
        checkbox = true; //When the object is first spawned. Checkbox is checked.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
