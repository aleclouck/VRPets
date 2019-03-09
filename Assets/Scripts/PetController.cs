using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetController : MonoBehaviour
{
    //public int testNumber;
    private VoiceDetection.SpeechToText command = new VoiceDetection.SpeechToText();
    private PetManager.Pet pet;
    private Rigidbody petBody;

    public float jumpForce = 14.0f;

    // Start is called before the first frame update
    void Start()
    {
        //testNumber = 0;
        pet = new PetManager.Pet();
        DisplayPetStatus();
        
        command.AddWord("jump");

        petBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pet.Mood.ChangeMood();
            DisplayPetStatus();
        }
        if (command.Hears("jump")) {
            petBody.velocity = new Vector3(0, jumpForce, 0);
        }
    }

    public void DisplayPetStatus()
    {
        Debug.Log(pet.Name + " is feeling " + pet.Mood.State.ToString());
    }
}
