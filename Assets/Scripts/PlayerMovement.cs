using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private float playerSpeed;
    Animator animator;
    [SerializeField] private float playerRotateSpeed;

    // Start is called before the first frame update
    void Start()
    {
        controller = this.GetComponent<CharacterController>();
        animator = this.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(inputX, 0f, inputZ);
        controller.SimpleMove(movement * playerSpeed * Time.deltaTime);

        animator.SetFloat("Speed", movement.magnitude);


        transform.Rotate(Vector3.up, inputX * playerRotateSpeed * Time.deltaTime);
        if (inputZ != 0)
        {
            controller.SimpleMove(transform.forward * Time.deltaTime);
        }
    }
}
