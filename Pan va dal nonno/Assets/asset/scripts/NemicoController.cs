using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class NemicoController : MonoBehaviour {

	private CharacterController nemico;

	public Text winText;

	// Use this for initialization
	void Start () {
	
		nemico = GetComponent<CharacterController> ();

	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter (Collider other){

		if (other.gameObject.CompareTag ("Attack")) {
			DestroyObject (nemico.gameObject);
			winText.gameObject.SetActive (true);
		}
	}
}
