using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public Rigidbody2D player;
	private GameObject[] platforms;
	void Start () {
		GameObject g = GameObject.FindGameObjectWithTag ("Player");
		player = g.GetComponent<Rigidbody2D> ();

		platforms = GameObject.FindGameObjectsWithTag ("platform");
		Debug.Log ("player null? " + player == null);
		Debug.Log ("platforms : " + platforms.Length);
	}
	
	void Update () {
		foreach (GameObject go in platforms){
			Debug.Log (go.tag);
			BoxCollider2D coll = go.GetComponent<BoxCollider2D> ();
			coll.enabled = !(player.velocity.y > .3);			
		}
	}
}
