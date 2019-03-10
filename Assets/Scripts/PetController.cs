using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetController : MonoBehaviour
{
    //public int testNumber;
    //private VoiceDetection.SpeechToText petEars = new VoiceDetection.SpeechToText();
    private PetManager.Pet pet;
    private Rigidbody petBody;

    public float jumpForce = 14.0f;

    // Start is called before the first frame update
    void Start()
    {
        //testNumber = 0;
        pet = new PetManager.Pet();
        DisplayPetStatus();

        VoiceDetection.SpeechToText.AddWord("jump");

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
        
        //jumps on voice command
        if (VoiceDetection.SpeechToText.Hears("jump")) {
            petBody.velocity = new Vector3(0, jumpForce, 0);
            FindObjectOfType<GameAudio.AudioManager>().Play("Jump");
        }

    }

    public void DisplayPetStatus()
    {
        Debug.Log(pet.Name + " is feeling " + pet.Mood.State.ToString());
    }
}
