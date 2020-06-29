using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lazerHit : MonoBehaviour
{
    public GameObject thisLazer;
    public Transform whereLazer;
    void FixedUpdate()
    {
        if (GameManager.instance.gameScrollingShip)
        {
            // this puts the object back on the other side of the screen if it would go off
            if (whereLazer.localPosition.x >= GameManager.instance.screenSizeX + 0.5f)
            {
                whereLazer.localPosition += new Vector3(-(GameManager.instance.screenSizeX * 2f), 0, 0);
            }
            if (whereLazer.localPosition.x <= -GameManager.instance.screenSizeX - 0.5f)
            {
                whereLazer.localPosition += new Vector3((GameManager.instance.screenSizeX * 2f), 0, 0);
            }
            if (whereLazer.localPosition.y >= GameManager.instance.screenSizeY + 0.5f)
            {
                whereLazer.localPosition += new Vector3(0, -(GameManager.instance.screenSizeY * 2f), 0);
            }
            if (whereLazer.localPosition.y <= -GameManager.instance.screenSizeY - 0.5f)
            {
                whereLazer.localPosition += new Vector3(0, (GameManager.instance.screenSizeY * 2f), 0);
            }
        }
        else
        {
            // this is the code called for by the class project
            if (whereLazer.localPosition.x >= GameManager.instance.screenSizeX | whereLazer.localPosition.x <= -GameManager.instance.screenSizeX)
            {
                Destroy(thisLazer);
            }
            if (whereLazer.localPosition.y >= GameManager.instance.screenSizeY | whereLazer.localPosition.y <= -GameManager.instance.screenSizeY)
            {
                Destroy(thisLazer);
            }
        }
    }
    public GameObject myStarShip;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
                     
            Destroy(thisLazer);
        
    }
}
