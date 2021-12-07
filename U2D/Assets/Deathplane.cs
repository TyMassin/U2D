using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deathplane : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerMovement>().enabled = false; //disable player control
            GameObject.FindGameObjectWithTag("MainCamera").transform.SetParent(null);//detatch camera from player
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false; //make player fall through world
            //collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 500)); //launch the player?
            //Destroy(this.gameObject);
        }
    }
}
