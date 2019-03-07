using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour {
    Rigidbody body;

    private float verticalVelocity;
    private float jumpForce = 10.0f;
    private float gravity = 14.0f;

    private void Start() {
        body = GetComponent<Rigidbody>();
    }

    private void Update() {
        if (verticalVelocity > 0) {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        Vector3 jumpMotion = new Vector3(0, verticalVelocity, 0);
        body.AddForce(jumpMotion);
    }

    public void DoJump() {
        if (verticalVelocity <= 0) {
            verticalVelocity = jumpForce;
        }
    }
}
