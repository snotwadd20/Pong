using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour 
{
	private Rigidbody2D rb2d = null;
	public float speed = 500;

	public GameObject leftRacket = null;
	public GameObject rightRacket = null;

	// Use this for initialization
	void Awake () 
	{
		rb2d = GetComponent<Rigidbody2D>();
	}//Awake

	void Start()
	{
		rb2d.velocity = Vector2.right * speed;
	}//Start

	float HitFactor(Vector2 ballPos, Vector2 racketPos, float racketHeight) 
	{
		// ascii art:
		// ||  1 <- at the top of the racket
		// ||
		// ||  0 <- at the middle of the racket
		// ||
		// || -1 <- at the bottom of the racket
		return (ballPos.y - racketPos.y) / racketHeight;
	}//HitFactor

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject != leftRacket && coll.gameObject != rightRacket)
			return;
		
		float x = 0;
		float y = HitFactor(transform.position, coll.transform.position, coll.collider.bounds.size.y);

		if (coll.gameObject == leftRacket)
			x = 1.0f;

		if (coll.gameObject == rightRacket)
			x = -1.0f;

		Vector2 dir = new Vector2(x,y).normalized;
		rb2d.velocity = dir * speed;
	}//OnCollisionEnter2D

	// Update is called once per frame
	void FixedUpdate () 
	{
	}//Update
}//
