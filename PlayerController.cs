using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using static UnityEngine.GraphicsBuffer;
public class PlayerController : MonoBehaviour
{
    private float speed = 25.0f;
    private float boundary = 8.5f;
    private float HorizontalInput;


    //public GameManager GameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Getting the input axis
        HorizontalInput = Input.GetAxis("Horizontal");
        //Moves the basket left and right
        transform.Translate(Vector3.right * speed * Time.deltaTime * HorizontalInput);
         //Boundary of the right position
        if (transform.position.x > boundary)
        {
            transform.position = new Vector3(boundary, transform.position.y, transform.position.z);
        }
        //Boundary of the left position
        if (transform.position.x < -boundary)
        {
            transform.position = new Vector3(-boundary, transform.position.y, transform.position.z);
        }
    }


}
