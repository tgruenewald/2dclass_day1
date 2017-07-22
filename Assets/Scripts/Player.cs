﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	private float move;
	private bool jump;
	public float maxSpeed = 3.0f;
	public float jumpForce = 20f;
	public bool grounded = true;
    public LayerMask whatIsGround;
	private CircleCollider2D groundCheck;
	private Animator animator;
	// Use this for initialization
	void Start () {
		groundCheck = GetComponent<CircleCollider2D>();
		animator = GetComponent<Animator>();
	}

	
	// Update is called once per frame
	void Update () {
		grounded = groundCheck.IsTouchingLayers (whatIsGround);

		move = Input.GetAxis ("Horizontal");
		if (move != 0) {
			animator.SetBool("isMoving", true);
		}
		else {
			animator.SetBool("isMoving", false);
		}

		jump = Input.GetButtonDown ("Jump") || Input.GetButtonDown ("Vertical");
		
		//Debug.Log ("move = " + move);
	}
	void FixedUpdate () {
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (move * maxSpeed, GetComponent<Rigidbody2D> ().velocity.y);	
		if (grounded && jump) {
			GetComponent<Rigidbody2D> ().AddForce(new Vector2(0f, jumpForce));
		}
	}
}
