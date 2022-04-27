using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private float playerSpeed;
    Animator animator;
    [SerializeField] private float rotateSpeed;

    // Start is called before the first frame update
    void Start()
    {
        controller = this.GetComponent<CharacterController>();
        animator = this.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal") * playerSpeed;
        float inputZ = Input.GetAxis("Vertical") * playerSpeed;
        Vector3 movement = new Vector3(inputX, 0f, inputZ);

        animator.SetFloat("Speed", movement.magnitude);

        transform.Rotate(Vector3.up, inputX * rotateSpeed * Time.deltaTime);
        if (inputZ != 0)
        {
            controller.Move(transform.forward * Time.deltaTime * inputZ);
        }

    }
}
