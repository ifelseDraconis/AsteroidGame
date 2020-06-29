using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject thisManager;

    public bool gameScrollingRocks;
    public float startHurtle;

    public float screenSizeX;
    public float screenSizeY;

    public bool autoDestroyRocks;
    public float destroyDelay;

    public float lazerSpeed;
    public float lazerDiesAfter;
    public bool lazerDiesOffscreen;

    public float speedShip;
    public float rotationSpeedShip;
    public bool gameScrollingShip;
    public bool thrustSkatesShip;
    public float startingRotationShip;
    public float chaseSpeed;

    public int spawnCount;
    public int spawnTime;
    public int spawnDelay;

    public GameObject prefabA;
    public GameObject prefabB;
    public GameObject prefabC;
    public GameObject prefabD;
    public GameObject prefabE;
    public GameObject prefabF;

    public int playerLives;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(thisManager);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
