using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drywall : MonoBehaviour
{
    SpriteRenderer drywall;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        drywall = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        AngleDrywall();
    }

    void AngleDrywall()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.localPosition = new Vector3(3.5f, 2, 0);
            transform.localRotation = Quaternion.Euler(0, 0, 90);
        }

        else if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.localPosition = new Vector3(0, 4, 0);
            transform.localRotation = Quaternion.Euler(0, 0, 180);
        }

        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.localPosition = new Vector3(-3.5f, 2, 0);
            transform.localRotation = Quaternion.Euler(0, 0, 90);
        }
    }
}
