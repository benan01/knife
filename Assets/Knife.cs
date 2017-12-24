﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour {

	public Rigidbody rb;

	public float force=5;
	public float torque=20;

	private Vector3 startSwipe;
	private Vector3 endSwipe;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			startSwipe =Camera.main.ScreenToViewportPoint(Input.mousePosition);
		}

		if (Input.GetMouseButtonUp (0)) {
			endSwipe = Camera.main.ScreenToViewportPoint(Input.mousePosition);
			Swipe ();
		}

	}
	void Swipe()
	{
		rb.isKinematic = false;
		Vector2 swipe = endSwipe - startSwipe;
		rb.AddForce (swipe*force, ForceMode.Impulse);
		rb.AddTorque (0f,0f,torque,ForceMode.Impulse);
	}
	private void OnTriggerEnter()
	{
		rb.isKinematic = true;

	}
}
