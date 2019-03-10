using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PetController : MonoBehaviour {
    private VoiceDetection.SpeechToText petEars;
    private PetManager.Pet pet;
    private Rigidbody petBody;

    public float jumpForce = 14.0f;

    // Start is called before the first frame update
    void Start() {
        pet = new PetManager.Pet();
        DisplayPetStatus();

        petBody = GetComponent<Rigidbody>();

        petEars = gameObject.AddComponent<VoiceDetection.SpeechToText>();
        petEars.AddWord("jump");
        petEars.AddWord("hello");
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0))
        {
            pet.Mood.ChangeMood();
            DisplayPetStatus();
        }
        
        //jumps on voice command
        if (petEars.Hears("jump")) {
            petBody.velocity = new Vector3(petBody.velocity.x,
                                            jumpForce,
                                            petBody.velocity.z);
            FindObjectOfType<GameAudio.AudioManager>().Play("Jump");
        }

        //greets when greeted
        if (petEars.Hears("hello")) {
            FindObjectOfType<GameAudio.AudioManager>().Play("Hihi");
        }
    }

    public void DisplayPetStatus() {
        Debug.Log(pet.Name + " is feeling " + pet.Mood.State.ToString());
    }
}
