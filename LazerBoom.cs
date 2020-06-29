using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerBoom : MonoBehaviour
{
    public GameObject kaBoom;
    public GameObject thisLazer;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
        Destroy(thisLazer);
    }
}
