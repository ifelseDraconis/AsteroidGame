using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class ssControl : MonoBehaviour
{
    public GameManager instance;
    public GameObject thisShip;
    public Transform tf;
    public GameObject fireZone;
    public Transform firingZone;

    private GameManager thisBoss;

    public Rigidbody2D builtBySquare;
    public GameObject thisLazer;

    private float screenSizeX;
    private float screenSizeY;

    private float speedShip;
    private float rotationSpeedShip;
    public float startingRotationShip;

    private bool gameScrollingShip;
    private bool thrustSkatesShip;
    
    private bool canMoveShip = true;

    private LazerFiring pewPew;
    
    // Start is called before the first frame update
    void Start()
    {
        screenSizeX = GameManager.instance.screenSizeX;
        screenSizeY = GameManager.instance.screenSizeY;
        speedShip = GameManager.instance.speedShip;
        rotationSpeedShip = GameManager.instance.rotationSpeedShip;
        startingRotationShip = GameManager.instance.startingRotationShip;
        gameScrollingShip = GameManager.instance.gameScrollingShip;
        thrustSkatesShip = GameManager.instance.thrustSkatesShip;

        pewPew = fireZone.GetComponent<LazerFiring>();

        builtBySquare = GetComponent<Rigidbody2D>();
        builtBySquare.rotation = GameManager.instance.startingRotationShip;
    }

    // Update is called once per frame
    void Update()
    {
        // toggle for when the player can or cannont move the ship
        if (Input.GetKeyDown("p"))
        {
            if (canMoveShip)
            {
                canMoveShip = false;
            }
            else
            {
                canMoveShip = true;
            }
        }
        // Checks ship movement state before allowing the player the move the ship
        if (canMoveShip)
        {

            // Movement for when the shift key is held down
            if (Input.GetKey("left shift") | Input.GetKey("right shift"))
            {
                if (Input.GetKeyDown("up") | Input.GetKeyDown("w"))
                {
                    tf.localPosition += (GetComponent<Transform>().TransformDirection(new Vector3(1, 0, 0)) * 1.5f * GameManager.instance.speedShip);
                }

                if (Input.GetKeyDown("down") | Input.GetKeyDown("s"))
                {
                    tf.localPosition -= (GetComponent<Transform>().TransformDirection(new Vector3(1, 0, 0)) * 1.5f * GameManager.instance.speedShip);
                }

                if (Input.GetKeyDown("left") | Input.GetKeyDown("a"))
                {
                    tf.localPosition += (GetComponent<Transform>().TransformDirection(new Vector3(0, 1, 0)) * 1.5f * GameManager.instance.speedShip);
                }

                if (Input.GetKeyDown("right") | Input.GetKeyDown("d"))
                {
                    tf.localPosition -= (GetComponent<Transform>().TransformDirection(new Vector3(0, 1, 0)) * 1.5f * GameManager.instance.speedShip);
                }
            }
            else
            {
                if (GameManager.instance.thrustSkatesShip)
                {
                    // this will cover what happens if applying forward motion while not holding the shift key happens
                    if (Input.GetKey("up") | Input.GetKey("w"))
                    {
                        builtBySquare.AddForce(GetComponent<Transform>().TransformDirection(new Vector3(1, 0, 0)) * GameManager.instance.speedShip, ForceMode2D.Impulse);                        
                    }

                    if (Input.GetKey("down") | Input.GetKey("s"))
                    {
                        builtBySquare.AddForce(GetComponent<Transform>().TransformDirection(new Vector3(-1, 0, 0)) * GameManager.instance.speedShip, ForceMode2D.Impulse);                        
                    }
                }
                else
                {
                    // Movement for when the shift key is not held down
                    if (Input.GetKey("up") | Input.GetKey("w"))
                    {
                        tf.localPosition += (GetComponent<Transform>().TransformDirection(new Vector3(1, 0, 0)) * 0.25f * GameManager.instance.speedShip);
                    }

                    if (Input.GetKey("down") | Input.GetKey("s"))
                    {
                        tf.localPosition -= (GetComponent<Transform>().TransformDirection(new Vector3(1, 0, 0)) * 0.25f * GameManager.instance.speedShip);
                    }

                }

                // this handles rotation
                if (Input.GetKey("left") | Input.GetKey("a"))
                {
                    builtBySquare.rotation += 0.5f * GameManager.instance.rotationSpeedShip;
                }

                if (Input.GetKey("right") | Input.GetKey("d"))
                {
                    builtBySquare.rotation -= 0.5f * GameManager.instance.rotationSpeedShip;
                }
            }

            // this portion of the code causes the ship to fire
            if (Input.GetKeyDown("space"))
            {
                pewPew.fireTheLazer();
            }

            // Returns the starship back to the starting global (0, 0, 0)
            if (Input.GetKeyDown("h"))
            {
                tf.localPosition = new Vector3(0, 0, 0);
                builtBySquare.rotation = GameManager.instance.startingRotationShip;
                builtBySquare.velocity = Vector3.zero;
                builtBySquare.angularVelocity = 0f;
            }
        }
        // outside of the ship movement state, to allow use of command buttons when ship movement is disabled
        // Ends the application
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        // Makes the Starship game object inactive by setting its active state to false
        //if (Input.GetKeyDown("q"))
        //{
        //    thisShip.SetActive(false);
        //}
        if (GameManager.instance.gameScrollingShip)
        {
            // this puts the object back on the other side of the screen if it would go off
            if (tf.localPosition.x >= GameManager.instance.screenSizeX + 0.5f)
            {
                tf.localPosition += new Vector3(-(GameManager.instance.screenSizeX * 2f), 0, 0);
            }
            if (tf.localPosition.x <= -GameManager.instance.screenSizeX - 0.5f)
            {
                tf.localPosition += new Vector3((GameManager.instance.screenSizeX * 2f), 0, 0);
            }
            if (tf.localPosition.y >= GameManager.instance.screenSizeY + 0.5f)
            {
                tf.localPosition += new Vector3(0, -(GameManager.instance.screenSizeY * 2f), 0);
            }
            if (tf.localPosition.y <= -GameManager.instance.screenSizeY - 0.5f)
            {
                tf.localPosition += new Vector3(0, (GameManager.instance.screenSizeY * 2f), 0);
            }
        }
        else
        {
            // this is the code called for by the class project
            if (tf.localPosition.x >= GameManager.instance.screenSizeX | tf.localPosition.x <= -GameManager.instance.screenSizeX)
            {
                Destroy(thisShip);
            }
            if (tf.localPosition.y >= GameManager.instance.screenSizeY | tf.localPosition.y <= -GameManager.instance.screenSizeY)
            {
                Destroy(thisShip);
            }
        }
    }
    public void Respawn()
    {
        tf.localPosition = new Vector3(0, 0, 0);
        builtBySquare.rotation = startingRotationShip;
        builtBySquare.velocity = Vector3.zero;
        builtBySquare.angularVelocity = 0f;
    }
}

