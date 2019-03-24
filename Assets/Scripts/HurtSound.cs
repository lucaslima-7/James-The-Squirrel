using UnityEngine;
using System.Collections;

public class HurtSound : MonoBehaviour {

	public AudioSource Hurt;
	public AudioClip hurt;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.tag == "Attack") {
			Hurt.PlayOneShot(hurt);
			Debug.Log("Audio Play");
		}
	}
}