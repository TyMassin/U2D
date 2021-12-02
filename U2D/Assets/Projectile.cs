using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float lifespan = 10;
    public float speed = 5;
    private Vector2 velocity;
    private Vector2 targetLocation;

    private Rigidbody2D projectile;

    private void Start()
    {
        targetLocation = (this.transform.position - GameObject.FindGameObjectWithTag("Player").transform.position).normalized * -1;
        velocity = targetLocation.normalized * speed;
        projectile = this.GetComponent<Rigidbody2D>();
        this.projectile.isKinematic = false; //Maybe work?
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Drywall")
        {
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerMovement>().enabled = false; //disable player control
            GameObject.FindGameObjectWithTag("MainCamera").transform.SetParent(null);//detatch camera from player
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false; //make player fall through world
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,500)); //launch the player?
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate()
    {
        projectile.MovePosition(projectile.position + velocity * Time.fixedDeltaTime);
        lifespan -= Time.fixedDeltaTime;
        if (lifespan <= 0)
            Destroy(this.gameObject);
    }
}
