using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	/*Varible of Player*/
	private CharacterController player;

	public Rigidbody Attack;

	private float gravity = 0.80f;

	public float speed = 10.0f;
	public float jumpSpeed = 5.0f;

	private float jump = 0.0f;
	private float movementJump;
	private Vector3 movPlayer;

	public float SuperjumpSpeed = 10.0f;
	public float timeAttack = 0.25f;
	public float forceAttack = 3000.0f;

	private float attackSpawn = 0.0f;

	/*Variable of Game*/

	private int score;
	private bool superJump = false;
	private bool PowerBlue = false;
	public Text textScore;

	public int nCandyBlue;
	public int nCandyGreen;
	public int nCandyRed;

	public AudioClip sfxCandy;
	public AudioClip sparo;

	// Use this for initialization
	void Start () {
		
		player = GetComponent<CharacterController> ();
		movementJump = 0.0f;
		score = 0;
		nCandyBlue = 11;
		nCandyGreen = 5;
		nCandyRed = 3;
	}

	void Update () {

		textScore.text = "Score: " + score;
	}

	// Update is called once per frame
	void FixedUpdate () {

		float directionfire;

		float movementVertical = Input.GetAxis ("Horizontal");
		float movementHorizontal = Input.GetAxis ("Vertical");
		jump = Input.GetAxis ("Jump");
		float boom = Input.GetAxis ("Fire");

		if (!(player.isGrounded)) {
			movementJump -= gravity;

		} else {	
			movementJump = jump * jumpSpeed;
		}

		if (superJump) {
			movementJump = SuperjumpSpeed;
			superJump = false;
		} 

		if(!(transform.position.x > 60 && transform.position.x < 100 )){
			movementHorizontal = 0.0f;
		}

		if (transform.position.z < 5.0f && movementHorizontal < 0) {
			movementHorizontal = 0;
		}

		if (transform.position.z > 53.0f && movementHorizontal > 0) {
			movementHorizontal = 0;
		}

		/*hai premuto il tasto c*/
		if (boom > 0 && PowerBlue) {
			/*Controllo il tempo passato dall'ultimo proietile uscito*/
			if (Time.time > attackSpawn + timeAttack) {

				if(movementVertical < 0){
					directionfire = -1;
				}else{
					directionfire = 1;
				}

				Rigidbody attack = (Rigidbody)Instantiate (Attack, transform.position + new Vector3 (1, 0, 0), transform.rotation);
				attack.AddForce (new Vector3 (directionfire, 0, 0) * forceAttack);
				GetComponent<AudioSource> ().PlayOneShot (sparo);
				attackSpawn = Time.time;
			}
		}

		movPlayer = new Vector3 (  movementVertical , movementJump , movementHorizontal);

		player.Move (movPlayer * speed * Time.deltaTime);

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("CandyBlue")) {
			score += 5;
			nCandyBlue -= 1;
			playMoney ();
			DestroyObject (other.gameObject);
		}


		if (other.gameObject.CompareTag ("CandyGreen")) {
			score += 10;
			nCandyGreen -= 1;
			playMoney ();
			DestroyObject (other.gameObject);
		}


		if (other.gameObject.CompareTag ("CandyRed")) {
			score += 25;
			nCandyRed -= 1;
			playMoney ();
			DestroyObject (other.gameObject);
		}

		if (other.gameObject.CompareTag ("SuperJump")) {
			superJump = true;
		}

		if(other.gameObject.CompareTag("FireBluePower")){
			PowerBlue = true;
			DestroyObject (other.gameObject);
		}
	}
		
	void playMoney (){
		GetComponent<AudioSource> ().PlayOneShot (sfxCandy);
	}

}
