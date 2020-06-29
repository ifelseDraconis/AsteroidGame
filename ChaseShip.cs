using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseShip : MonoBehaviour
{
    public GameManager instance;
    public GameObject theTarget;
    public Transform targetLocation;
    public GameObject enemyShip;
    public Rigidbody2D chaseMe;
    public Transform enemyLocation;

    private float chaseSpeed;

    // Start is called before the first frame update
    void Start()
    {
        if (theTarget == null)
        {
            theTarget = GameObject.FindWithTag("Player");
        }
        targetLocation = theTarget.GetComponent<Transform>();
        chaseSpeed = GameManager.instance.chaseSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // this updates every fixed update, making the enemy ship chase yours.  Still stupid fast.
        float xDiff = targetLocation.localPosition.x - enemyLocation.localPosition.x;
        float yDiff = targetLocation.localPosition.y - enemyLocation.localPosition.y;
        chaseMe.AddForce(new Vector3(xDiff * chaseSpeed, yDiff * chaseSpeed, 0));
        enemyLocation.LookAt(targetLocation);

        if (GameManager.instance.gameScrollingShip)
        {
            // this puts the object back on the other side of the screen if it would go off
            if (enemyLocation.localPosition.x >= GameManager.instance.screenSizeX + 0.5f)
            {
                enemyLocation.localPosition += new Vector3(-(GameManager.instance.screenSizeX * 2f), 0, 0);
            }
            if (enemyLocation.localPosition.x <= -GameManager.instance.screenSizeX - 0.5f)
            {
                enemyLocation.localPosition += new Vector3((GameManager.instance.screenSizeX * 2f), 0, 0);
            }
            if (enemyLocation.localPosition.y >= GameManager.instance.screenSizeY + 0.5f)
            {
                enemyLocation.localPosition += new Vector3(0, -(GameManager.instance.screenSizeY * 2f), 0);
            }
            if (enemyLocation.localPosition.y <= -GameManager.instance.screenSizeY - 0.5f)
            {
                enemyLocation.localPosition += new Vector3(0, (GameManager.instance.screenSizeY * 2f), 0);
            }
        }
        else
        {
            // this is the code called for by the class project
            if (enemyLocation.localPosition.x >= GameManager.instance.screenSizeX | enemyLocation.localPosition.x <= -GameManager.instance.screenSizeX)
            {
                Destroy(enemyShip);
            }
            if (enemyLocation.localPosition.y >= GameManager.instance.screenSizeY | enemyLocation.localPosition.y <= -GameManager.instance.screenSizeY)
            {
                Destroy(enemyShip);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        Destroy(enemyShip);
    }
}
