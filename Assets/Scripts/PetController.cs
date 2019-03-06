using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetController : MonoBehaviour
{
    //public int testNumber;
    private PetManager.Pet pet;

    // Start is called before the first frame update
    void Start()
    {
        //testNumber = 0;
        pet = new PetManager.Pet();
        DisplayPetStatus();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pet.Mood.ChangeMood();
            DisplayPetStatus();
        }
    }

    public void DisplayPetStatus()
    {
        Debug.Log(pet.Name + " is feeling " + pet.Mood.State.ToString());
    }
}
