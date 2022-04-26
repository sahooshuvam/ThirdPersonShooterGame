using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private float playerSpeed = 10f;
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
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(inputX, 0f, inputZ);
        controller.Move(movement * Time.deltaTime);

        animator.SetFloat("Speed", movement.magnitude);
        if (movement.magnitude > 0f)
        {
            Quaternion tempDirection = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Slerp(tempDirection, transform.rotation, Time.deltaTime * rotateSpeed);
        }
    }
}
