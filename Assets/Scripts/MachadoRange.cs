using UnityEngine;
using System.Collections;

public class MachadoRange : MonoBehaviour {

	public float playerRange;
	public GameObject Machado;
	public PlatformerCharacter2D player;
	public Transform launchPoint;
	public float Delay;
	private float shotCounter;



	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlatformerCharacter2D> ();
		shotCounter = Delay;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.DrawLine (new Vector3 (transform.position.x - playerRange, transform.position.y, transform.position.z), new Vector3(transform.position.x + playerRange, transform.position.y, transform.position.z));
		shotCounter -= Time.deltaTime;


		if (transform.localScale.x < 0  &&  player.transform.position.x > transform.position.x  &&  player.transform.position.x  <  transform.position.x + playerRange && shotCounter < 0){
			Instantiate(Machado, launchPoint.position, launchPoint.rotation);
			shotCounter = Delay;
		}

		if (transform.localScale.x > 0  &&  player.transform.position.x < transform.position.x  &&  player.transform.position.x  >  transform.position.x - playerRange && shotCounter < 0){
			Instantiate(Machado, launchPoint.position, launchPoint.rotation);
			shotCounter = Delay;
		}
	}
}
