using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject Projectile;

    private bool canAttack = false;
    private float DelayTracker = 0;
    public float interactionDistance = 5;
    public int attackDelay = 5;

    // Start is called before the first frame update
    void Start()
    {
        DelayTracker = attackDelay * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (canAttack)
        {
            Collider2D[] objectsInRange = Physics2D.OverlapCircleAll(transform.position, interactionDistance, 1);
            foreach(Collider2D x in objectsInRange)
            {
                if (x.tag == "Player")
                {
                    GameObject hurl = Instantiate(Projectile, 
                        new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), 
                        Quaternion.identity) as GameObject; //lets hope this works
                    canAttack = false;
                    DelayTracker = 0;
                }
            }
        }
        else
        {
            DelayTracker += Time.deltaTime;
            if(DelayTracker >= attackDelay)
            {
                canAttack = true;
            }
        }
    }
}
