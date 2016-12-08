using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour
{
    public static MenuController instance;

    [SerializeField]
    private GameObject[] birds;

    private bool isGreenBirdUnloacked, isRedBirdUnloacked;

    void Awake()
    {
        MakeInstance();
    }

	// Use this for initialization
	void Start()
    {
        birds[GameController.instance.GetSelectedBird()].SetActive(true);
        CheckIfBirdsAreUnlocked();

    }

    void MakeInstance()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void CheckIfBirdsAreUnlocked()
    {
        if(GameController.instance.IsGreenBirdUnlocked() == 1)
        {
            isGreenBirdUnloacked = true;
        }

        if (GameController.instance.IsRedBirdUnlocked() == 1)
        {
            isRedBirdUnloacked = true;
        }
    }

    public void ChangeBird()
    {
        //If blue bird selected
        if(GameController.instance.GetSelectedBird() == 0)
        {
            //If green bird is unlocked
            if(isGreenBirdUnloacked)
            {
                birds[0].SetActive(false); //Deactivate the blue bird
                GameController.instance.SetSelectedBird(1); //Index of green bird
                birds[GameController.instance.GetSelectedBird()].SetActive(true); //Activate green bird
            }
        }
        else if(GameController.instance.GetSelectedBird() == 1)
        {
            //If green bird is unlocked
            if (isRedBirdUnloacked)
            {
                birds[1].SetActive(false); //Deactivate the green bird
                GameController.instance.SetSelectedBird(2); //Index of red bird
                birds[GameController.instance.GetSelectedBird()].SetActive(true); //Activate red bird
            }
            else
            {
                birds[1].SetActive(false); //Deactivate the green bird
                GameController.instance.SetSelectedBird(0); //Index of blue bird
                birds[GameController.instance.GetSelectedBird()].SetActive(true); //Activate blue bird
            }
        }
        else if(GameController.instance.GetSelectedBird() == 2)
        {
            birds[2].SetActive(false); //Deactivate the red bird
            GameController.instance.SetSelectedBird(0); //Index of blue bird
            birds[GameController.instance.GetSelectedBird()].SetActive(true); //Activate blue bird
        }
    }
}
