using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sLazerFiring : MonoBehaviour
{
    public GameManager instance;
    public GameObject thisStarShip;
    public Rigidbody2D thatCruise;
    public Transform thatShooter;
    public GameObject thisLazer;
    public Rigidbody2D zapZapForce;

    private bool gameScrollingRocks;
    private float startHurtle;

    private float screenSizeX;
    private float screenSizeY;

    private float lazerSpeed;
    private bool lazerDiesOffscreen;
    private float lazerDiesAfter;

    // Start is called before the first frame update
    void Start()
    {
        lazerSpeed = GameManager.instance.lazerSpeed;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void fireTheLazer()
    {
        GameObject newLaser = Instantiate(thisLazer, thatShooter.position, thatShooter.rotation);
        newLaser.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.right * lazerSpeed);
        newLaser.GetComponent<Transform>();
        Destroy(thisLazer, lazerDiesAfter);
        UnityEngine.Debug.Log("pewpew");
    }


}
