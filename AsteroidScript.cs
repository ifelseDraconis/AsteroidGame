using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public GameManager instance;
    private Transform smishTarget;
    private GameObject theShip;

    // the various classes and containers that asteroid makes use of
    [SerializeField]
    public GameObject thisSkyRock;

    [SerializeField]
    public Transform spaceRock;

    [SerializeField]
    public Rigidbody2D rockMe;

    [SerializeField]
    public CircleCollider2D thisHitter;

    [SerializeField]
    private float destroyDelay;

    private bool gameScrollingRocks;
    private float startHurtle;

    private float screenSizeX;
    private float screenSizeY;

    private bool autoDestroyRocks;    
    
    // Start is called before the first frame update
    void Start()
    {
        if (theShip == null)
        {
            theShip = GameObject.FindWithTag("Player");
        }
        smishTarget = theShip.GetComponent<Transform>();
        gameScrollingRocks = GameManager.instance.gameScrollingRocks;
        startHurtle = GameManager.instance.startHurtle;
        screenSizeX = GameManager.instance.screenSizeX;
        screenSizeY = GameManager.instance.screenSizeY;
        autoDestroyRocks = GameManager.instance.autoDestroyRocks;
        destroyDelay = GameManager.instance.destroyDelay;

        float xDiff = smishTarget.localPosition.x - spaceRock.localPosition.x;
        float yDiff = smishTarget.localPosition.y - spaceRock.localPosition.y;
        rockMe.AddForce(new Vector3(xDiff * startHurtle, yDiff * startHurtle, 0));

        if (autoDestroyRocks)
        {
            Destroy(thisSkyRock, destroyDelay);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (gameScrollingRocks)
        {
            // this puts the object back on the other side of the screen if it would go off
            if (spaceRock.localPosition.x >= screenSizeX + 0.5f)
            {
                spaceRock.localPosition += new Vector3(-(screenSizeX * 2f), 0, 0);
            }
            if (spaceRock.localPosition.x <= -screenSizeX - 0.5f)
            {
                spaceRock.localPosition += new Vector3((screenSizeX * 2f), 0, 0);
            }
            if (spaceRock.localPosition.y >= screenSizeY + 0.5f)
            {
                spaceRock.localPosition += new Vector3(0, -(screenSizeY * 2f), 0);
            }
            if (spaceRock.localPosition.y <= -screenSizeY - 0.5f)
            {
                spaceRock.localPosition += new Vector3(0, (screenSizeY * 2f), 0);
            }
        }
        else
        {
            // this puts destroys the object if it goes off screen
            if (spaceRock.localPosition.x >= screenSizeX + 0.5f)
            {
                Destroy(thisSkyRock);
            }
            if (spaceRock.localPosition.x <= -screenSizeX - 0.5f)
            {
                Destroy(thisSkyRock);
            }
            if (spaceRock.localPosition.y >= screenSizeY + 0.5f)
            {
                Destroy(thisSkyRock);
            }
            if (spaceRock.localPosition.y <= -screenSizeY - 0.5f)
            {
                Destroy(thisSkyRock);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        Destroy(thisSkyRock);

    }

}
