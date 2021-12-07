using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class victory : MonoBehaviour
{
    public GameObject toggle;
    private void Start()
    {
        toggle.transform.localScale = new Vector2(0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            toggle.transform.localScale = new Vector2(1,1);
        }
    }
}
