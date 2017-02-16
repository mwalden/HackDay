using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public Rigidbody2D player;
	private GameObject[] platforms;
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Rigidbody2D>();
		platforms = GameObject.FindGameObjectsWithTag ("platform");
		Debug.Log ("player null? " + player == null);
			
	}
	
	void Update () {
		foreach (GameObject go in platforms){
			BoxCollider2D coll = go.GetComponent<BoxCollider2D> ();
			coll.enabled = !(player.velocity.y > .3);			
		}
	}
}
