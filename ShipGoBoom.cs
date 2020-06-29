using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using UnityEngine;

public class ShipGoBoom : MonoBehaviour
{
    public GameManager instance;
    public GameObject kaBoom;
    public GameObject thisShip;

    private ssControl rez;

    void Start()
    {
        rez = GetComponent<ssControl>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
        if (GameManager.instance.playerLives > 0)
        {
            // respawn the player if they have lives left
            GameManager.instance.playerLives--;
            rez.Respawn();
        }
        else
        {
            // a complete goodbye
            Destroy(thisShip);
        }
        
    }
}
