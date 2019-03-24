using UnityEngine;
using System.Collections;

	public class LevelManager : MonoBehaviour {

	public GameObject RespawnEffect;
	public float RespawnDelay;
	public GameObject CheckPoint;
	public int penalty;
	private PlatformerCharacter2D player;
	private CameraController camera;
	public string GameOver;


	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlatformerCharacter2D> ();
		camera = FindObjectOfType<CameraController> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Respawn () {

		StartCoroutine ("RespawnPlayerCoroutine");
		// Instantiate (RespawnEffect, CheckPoint.transform.position, CheckPoint.transform.rotation);
	}

	public IEnumerator RespawnPlayerCoroutine(){

		player.transform.position = CheckPoint.transform.position;
		player.enabled = false;
		player.GetComponent<Renderer> ().enabled = false;
		player.GetComponent<BoxCollider2D> ().enabled = false;
		camera.isFollowing = false;
		Collectables.AddPoints (-penalty);
		yield return new WaitForSeconds (2);
		Application.LoadLevel (GameOver);
		//Debug.Log ("Player Respawn");
		//yield return new WaitForSeconds (RespawnDelay);
		//player.transform.position = CheckPoint.transform.position;
		//player.enabled = true;
		//player.GetComponent<Renderer> ().enabled = true;
		//player.GetComponent<BoxCollider2D> ().enabled = true;
		//camera.isFollowing = true;
	}
}
