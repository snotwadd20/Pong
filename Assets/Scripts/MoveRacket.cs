using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRacket : MonoBehaviour 
{
	public float speed = 100;
	private Rigidbody2D rb2d = null;
	private float inputV = 0;

	public string axis = "Vertical";

	// Use this for initialization
	void Awake () 
	{
		rb2d = GetComponent<Rigidbody2D>();
	}//Awake

	void Update()
	{
		inputV = Input.GetAxisRaw(axis);
	}//Update

	// Update is called once per frame
	void FixedUpdate () 
	{
		rb2d.velocity = Vector2.up * inputV * speed * Time.deltaTime;
	}//FixedUpdate
}//MoveRacket