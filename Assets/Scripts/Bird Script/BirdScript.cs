using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BirdScript : MonoBehaviour
{
    public static BirdScript instance; //Used to created a class that can e accessed from anywhere

    [SerializeField]
    private Rigidbody2D myRidgidBody; //Used for our ridgidbody

    [SerializeField]
    private Animator anim; //Used for our animations

    private float forwardSpeed = 3f;
    private float bounceSpeed = 4f;

    private bool didFlap; //Used for movment
    public bool isAlive;  //Used to see if bird is alive
    private Button flapButton; //This will be how we program our button to flap

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        isAlive = true;

        //This is how we make our flabButton represent our Flab Button on the unity editor
        flapButton = GameObject.FindGameObjectWithTag("FlapButton").GetComponent<Button>();
        flapButton.onClick.AddListener(() => FlapTheBird()); //Here we are making the button call the method FlapTheBird on click

        SetCamerasX();
    }

	// Use this for initialization
	void Start()
    {
	
	}
	
	// Update is called once ever few frame
	void FixedUpdate()
    {
        //If bird is alive
	    if(isAlive)
        {
            Vector3 temp = transform.position; //Current postion of our bird
            temp.x += forwardSpeed * Time.deltaTime; //Preparing to move bird forward by adding our speed plus the amount of time gone by
            transform.position = temp; //Now we set the current postioion, effectvly moving our bird

            //If bird has flapped
            if(didFlap)
            {
                didFlap = false; //Reset
                myRidgidBody.velocity = new Vector2(0, bounceSpeed);
                anim.SetTrigger("Flap"); //Using animation
            }

            //Basically if everything is fine
            if(myRidgidBody.velocity.y >= 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else //Else we start to turn our bird onto an angle
            {
                float angle = 0;
                angle = Mathf.Lerp(0, -90, -myRidgidBody.velocity.y / 7);
                transform.rotation = Quaternion.Euler(0, 0, angle);
            }
        }
	}

    void SetCamerasX()
    { //Set offsetX in cameraScript
        CameraScript.offsetX = (Camera.main.transform.position.x - transform.position.x) - 1f;
    }

    public float GetPositionX()
    { //Returns position x of our bird
        return transform.position.x;
    }

    public void FlapTheBird()
    {
        didFlap = true;
    }
}
