using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifeOfBolt : MonoBehaviour {

	private Rigidbody sfera;

	private float time;
	public float dead = 0.3f;

	// Use this for initialization
	void Start () {

		sfera = GetComponent<Rigidbody> ();

		time = Time.time;
	}
	
	// Update is called once per frame
	void Update () {

		if (Time.time > time + dead)
			DestroyObject (sfera.gameObject);

	}

	void FixedUpdate(){
	}
}
