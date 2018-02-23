using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePower : MonoBehaviour {

	private Rigidbody sfera;

	// Use this for initialization
	void Start () {

		sfera = GetComponent<Rigidbody> ();

	}

	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnetr(Collider other){

		if (other.gameObject.CompareTag ("Player")) {
				DestroyObject(sfera.gameObject);
		}
	}
		
}
