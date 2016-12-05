using UnityEngine;
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
    private bool isAlive;  //Usev to see if bird is alive

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        isAlive = true;
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
        }
	}

    public void FlapTheBird()
    {
        didFlap = true;
    }
}
